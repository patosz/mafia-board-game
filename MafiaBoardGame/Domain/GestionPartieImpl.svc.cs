using Domain.Dto;
using Domain.Model;
using Domain.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Domain
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "GestionPartieImpl" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez GestionPartieImpl.svc ou GestionPartieImpl.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class GestionPartieImpl : IGestionPartie
    {

        private static ModelContainer dbcontext;
        private Partie partie;
        private PartieDto partieDto;
        public GestionPartieImpl()
        {
            dbcontext = new ModelContainer();
        }
        public bool CommencerPartie()
        {
            throw new NotImplementedException();
        }

        public bool CreerPartie(String nomPartie, String nomJoueur)
        {

            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                             where j.Pseudo.Equals(nomJoueur)
                             select j).FirstOrDefault();

            if (joueur == null)
            {
                //TODO erreur a géré 
                return false;
            }

            if (partie != null && (int)partie.etat == (int)Partie.ETAT.EN_COURS)
            {
                return false;
            }

            if (partie == null || (int)partie.etat == (int)Partie.ETAT.TERMINE)
            {
                partie = new Partie(nomPartie);
                partie.etat = (int)Partie.ETAT.INSCRIPTION;
                // relation PartieJoueur 0..1 sinon EF demandera une référence joueur pour ce champ
                //partie.JoueurCourant = joueur;

                /*try
                {*/

                JoueurPartie joueurPartie = new JoueurPartie();

                //Joueur
                joueur.PartiesJouees.Add(joueurPartie);
                //joueur.PartiesGagnees.Add(partie);

                //JoueurPartie
                joueurPartie.Partie = partie;
                joueurPartie.Joueur = joueur;
                //joueurPartie.PartieCourant = partie;
                //joueurPartie.JoueurId = joueur.Id;


                //Partie
                partie.JoueursParticipants.Add(joueurPartie);
                //partie.JoueurCourant = joueurPartie;
                //partie.JoueurId = joueur.Id;

                //JoueurPartie
                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;
                //joueurPartie.JoueurId = joueur.Id;

                dbcontext.JoueurParties.Add(joueurPartie);
                //dbcontext.Joueurs.Add(joueur);
                dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Parties.Add(partie);


                dbcontext.SaveChanges();

                //création de la partieDto et on charge la partie
                //partieDto = BizToDto.ToPartieDto(partie);

                //    }
                /* catch (DbEntityValidationException e)
                 {
                     foreach (var eve in e.EntityValidationErrors)
                     {
                         System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                             eve.Entry.Entity.GetType().Name, eve.Entry.State);
                         foreach (var ve in eve.ValidationErrors)
                         {
                             System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                 ve.PropertyName, ve.ErrorMessage);
                         }
                     }
                     throw;


                 }*/
            }
            return true;
        }




        public string GetPartie()
        {
            string str = "";
            str += "Détails de la partie : \n";
            str += "Id : " + partie.Id + "\n";
            str += "Nom : " + partie.Nom + "\n";
            str += "Sens : " + partie.Sens + "\n";
            str += "Etat : " + partie.etat + "\n";
            str += "Heure de création : " + partie.DateHeureCreation + "\n";
            //str += "Joueur Courant :" + partie.JoueurCourant.Joueur.Pseudo + "\n";
            str += "Nb de participants : " + partie.JoueursParticipants.Count + "\n";
            return str;
        }

        //on donne quoi le string un objet??
        public bool RejoindrePartie(string pseudo)
        {
            if (partie.maxJoueur>=partie.JoueursParticipants.Count)
            {
                return false;
            }
            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                             where j.Pseudo.Equals(pseudo)
                             select j).FirstOrDefault();
            //Pas de création!
            if (partie == null)
            {
                return false;
            }
            if (partie != null && (int)partie.etat == (int)Partie.ETAT.EN_COURS)
            {
                return false;
            }

            if ((int)partie.etat == (int)Partie.ETAT.INSCRIPTION)
            {

                //TODO Debug exception de merde
                JoueurPartie joueurPartie = new JoueurPartie();
                joueurPartie.Partie = partie;
                dbcontext.JoueurParties.Add(joueurPartie);
                //dbcontext.SaveChanges();

                joueur.PartiesJouees.Add(joueurPartie);
                partie.JoueursParticipants.Add(joueurPartie);

                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;
                //est ce que je dois vraiment mettre la partie courante?
                joueurPartie.Partie = partie;
                joueurPartie.Joueur = joueur;
                //joueurPartie.PartieCourant = partie;

                //est ce que je dois vraiment mettre la JoueurCourant courante?
                partie.JoueursParticipants.Add(joueurPartie);
                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;

                dbcontext.JoueurParties.Add(joueurPartie);
                //dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;

                dbcontext.SaveChanges();

                //A relationship from the 'PartieJoueurPartie' AssociationSet is in the 'Deleted' state. Given multiplicity constraints, a corresponding 'PartieJoueur' must also in the 'Deleted' state.

                //partie.JoueurCourant = joueurPartie;


                //dbcontext.SaveChanges();

                //dbcontext.Joueurs.Add(joueur);

                //dbcontext.Parties.Add(partie);

                //dbcontext.SaveChanges();


                /* catch (DbEntityValidationException e)
                 {
                     foreach (var eve in e.EntityValidationErrors)
                     {
                         System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                             eve.Entry.Entity.GetType().Name, eve.Entry.State);
                         foreach (var ve in eve.ValidationErrors)
                         {
                             System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                 ve.PropertyName, ve.ErrorMessage);
                         }
                     }
                     throw;


                 }*/
            }

            return true;
        }

        public List<PartieDto> VoirPartie(string pseudo)
        {
            List<PartieDto> list = new List<PartieDto>();

            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                             where j.Pseudo.Equals(pseudo)
                             select j).FirstOrDefault();
            List<JoueurPartie> jp = joueur.PartiesJouees.ToList();


            for (int i = 0; i < jp.Count; i++)
            {
                int idJp = jp.ElementAt(i).PartieId;
                Partie partie = (from Partie p in dbcontext.Parties
                                 where p.Id == idJp
                                 select p).FirstOrDefault();

                PartieDto partieDto = BizToDto.ToPartieDto(partie);
                list.Add(partieDto);
            }

            return list;

        }

        public PartieDto LancerPartie()
        {
            List<JoueurPartie> listeJoueurPartie =partie.JoueursParticipants.ToList();
            for (int i= 0; i < listeJoueurPartie.Count; i++)
            {
                JoueurPartie joueurPartie =listeJoueurPartie.ElementAt(i);
                //recupere le nombre de carte
                int numCarteParjoueur = partie.nbCartesParJoueur;
                for(int j=0; j < numCarteParjoueur; j++)
                {
                    piocherCarte(joueurPartie.Id);
                }
                int numDeParJoueur = partie.nbParJoueur;
                for (int j = 0; j < numDeParJoueur; j++)
                {
                    initDe(joueurPartie.Id);
                }
            }

            return BizToDto.ToPartieDto(partie); ;
        }

        public CarteDto piocherCarte(int idJoueurPartie)
        {


            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(idJoueurPartie)
                                         select j).FirstOrDefault();

            Carte carte = partie.CartesPioche.First();

            partie.CartesPioche.Remove(carte);

            partie.CartesPoubelle.Add(carte);

            joueurPartie.CartesMain.Add(carte);

            
            dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            
            dbcontext.SaveChanges();
            CarteDto carteDto = BizToDto.ToCarteDto(carte);
            return carteDto;

        }

        public void initDe(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(IdJoueurPartie)
                                         select j).FirstOrDefault();
            De de = new De();
            joueurPartie.DesMain.Add(de);
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Des.Add(de);
            dbcontext.SaveChanges();

        }

        public List<DeDto> lancerDes(int IdJoueurPartie)
        {
            List<DeDto> listDeLance = new List<DeDto>();
            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(IdJoueurPartie)
                                         select j).FirstOrDefault();
            //shuffle
            foreach (De de in joueurPartie.DesMain)
            {
                //que faire une fois qu'on a le numéro
              int valeurDe=de.LancerDe();
            }

            return listDeLance;
        }

        //Service des Get Objet

        public JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(IdJoueurPartie)
                                         select j).FirstOrDefault();

            return BizToDto.ToJoueurPartieDto(joueurPartie);

        }

        public List<JoueurPartieDto> getListJoueurParticipantsDto(int IdPartie)
        {
            List<JoueurPartieDto> listJoueurPartie = new List<JoueurPartieDto>();
           var list = (from JoueurPartie j in dbcontext.JoueurParties
                       where j.PartieId.Equals(IdPartie)
                       select j);
            foreach (JoueurPartie joueurPartie in list)
            {
                listJoueurPartie.Add(BizToDto.ToJoueurPartieDto(joueurPartie));
            }


            return listJoueurPartie;
        }

        public List<DeDto> getListDesDto(int IdJoueurPartie)
        {
            List<DeDto> listDeDto = new List<DeDto>();
            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(IdJoueurPartie)
                                         select j).FirstOrDefault();
            foreach (De de in joueurPartie.DesMain)
            {
                listDeDto.Add(BizToDto.ToDeDto(de));
            }


            return listDeDto;
        }

        public List<CarteDto> getListCartesDto(int IdJoueurPartie)
        {
            List<CarteDto> listDeDto = new List<CarteDto>();
            JoueurPartie joueurPartie = (from JoueurPartie j in dbcontext.JoueurParties
                                         where j.Id.Equals(IdJoueurPartie)
                                         select j).FirstOrDefault();
            foreach (Carte carte in joueurPartie.CartesMain)
            {
                listDeDto.Add(BizToDto.ToCarteDto(carte));
            }


            return listDeDto;
        }

        public JoueurDto getJoueurDto(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                         where jp.Id.Equals(IdJoueurPartie)
                                         select jp).FirstOrDefault();

            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                                         where j.Id.Equals(joueurPartie.JoueurId)
                                         select j).FirstOrDefault();
            return BizToDto.ToJoueurDto(joueur);
        }

       
    }
}
