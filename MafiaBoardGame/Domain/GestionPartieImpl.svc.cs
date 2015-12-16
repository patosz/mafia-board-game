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

        public PartieDto CreerPartie(String nomPartie, String nomJoueur)
        {

            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                             where j.Pseudo.Equals(nomJoueur)
                             select j).FirstOrDefault();

            if (joueur == null)
            {
                //TODO erreur a géré 
                return null;
            }

            if (partie != null && (int)partie.etat == (int)Partie.ETAT.EN_COURS)
            {
                return null;
            }

            if (partie == null || (int)partie.etat == (int)Partie.ETAT.TERMINE)
            {
                partie = new Partie(nomPartie);
                partie.etat = (int)Partie.ETAT.INSCRIPTION;

                JoueurPartie joueurPartie = new JoueurPartie();
                joueurPartie.Partie = partie;

                joueurPartie.Joueur = joueur;
                dbcontext.JoueurParties.Add(joueurPartie);
                dbcontext.Parties.Add(partie);
                dbcontext.SaveChanges();
                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;

                partie.JoueurCourant = joueurPartie;
                dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

                joueur.PartiesJouees.Add(joueurPartie);

                dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;

                dbcontext.SaveChanges();


            }
            return BizToDto.ToPartieDto(partie);
        }




        public string GetPartieDebug()
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
            /* if (partie.maxJoueur >= partie.JoueursParticipants.Count)
             {
                 return false;
             }*/
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

                JoueurPartie joueurPartie = new JoueurPartie();
                joueurPartie.Partie = partie;
                dbcontext.JoueurParties.Add(joueurPartie);

                joueur.PartiesJouees.Add(joueurPartie);
                partie.JoueursParticipants.Add(joueurPartie);

                joueurPartie.Partie = partie;
                joueurPartie.Joueur = joueur;

                partie.JoueursParticipants.Add(joueurPartie);

                dbcontext.JoueurParties.Add(joueurPartie);

                dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
                dbcontext.SaveChanges();

                dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;

                dbcontext.SaveChanges();

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
            List<JoueurPartie> listeJoueurPartie = partie.JoueursParticipants.ToList();
            for (int i = 0; i < listeJoueurPartie.Count; i++)
            {
                JoueurPartie joueurPartie = listeJoueurPartie.ElementAt(i);
                //recupere le nombre de carte
                int numCarteParjoueur = partie.nbCartesParJoueur;
                for (int j = 0; j < numCarteParjoueur; j++)
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

        public CarteDto piocherCarte(int IdJoueurPartie)
        {


            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            Carte carte = partie.CartesPioche.First();

            partie.CartesPioche.Remove(carte);

            joueurPartie.CartesMain.Add(carte);


            dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;

            dbcontext.SaveChanges();
            CarteDto carteDto = BizToDto.ToCarteDto(carte);
            return carteDto;

        }

        public void initDe(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            De de = new De();
            joueurPartie.DesMain.Add(de);
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Des.Add(de);
            dbcontext.SaveChanges();

        }

        public List<DeDto> lancerDes(int IdJoueurPartie)
        {
            List<DeDto> listDeLance = new List<DeDto>();
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            //shuffle
            foreach (De de in joueurPartie.DesMain)
            {
                de.LancerDe();
                listDeLance.Add(BizToDto.ToDeDto(de));
            }
            dbcontext.SaveChanges();
            return listDeLance;
        }

        //Service des Get Objet

        public JoueurPartieDto getJoueurParticipantDto(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

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
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            foreach (De de in joueurPartie.DesMain)
            {
                listDeDto.Add(BizToDto.ToDeDto(de));
            }


            return listDeDto;
        }

        public List<CarteDto> getListCartesDto(int IdJoueurPartie)
        {
            List<CarteDto> listDeDto = new List<CarteDto>();
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            foreach (Carte carte in joueurPartie.CartesMain)
            {
                listDeDto.Add(BizToDto.ToCarteDto(carte));
            }


            return listDeDto;
        }

        public JoueurDto getJoueurDto(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);


            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                             where j.Id.Equals(joueurPartie.JoueurId)
                             select j).FirstOrDefault();
            return BizToDto.ToJoueurDto(joueur);
        }

        public bool autoriserCarte(int IdJoueurPartie, int cout)
        {
            int compteur = 0;
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            foreach (De de in joueurPartie.DesMain)
            {
                if (de.Valeur.Equals("M"))
                {
                    compteur++;
                }
            }
            if (compteur >= cout)
            {
                return true;
            }
            return false;
        }


        public bool donnerDe(int IdJoueurPartie, int IdJoueurCible)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);
            JoueurPartie joueurPartieCible = getJoueurPartie(IdJoueurCible);

            foreach (De de in joueurPartie.DesMain)
            {
                if (de.Valeur.Equals("D"))
                {
                    joueurPartie.DesMain.Remove(de);
                    joueurPartieCible.DesMain.Add(de);
                    dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.Entry(joueurPartieCible).State = System.Data.Entity.EntityState.Modified;

                    dbcontext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public void supprimerUnDe(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            joueurPartie.DesMain.Remove(joueurPartie.DesMain.ElementAt(0));

            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
        }

        public void supprimerDeuxDes(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            if (joueurPartie.DesMain.Count >= 2)
            {
                joueurPartie.DesMain.Remove(joueurPartie.DesMain.ElementAt(0));
                joueurPartie.DesMain.Remove(joueurPartie.DesMain.ElementAt(1));
            }
            else
            {
                //TODO vainqueur
            }


            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;

            dbcontext.SaveChanges();
        }

        //TODO verifier persistence dans db
        public void donnerDeAGaucheOuDroite()
        {

            List<JoueurPartie> listParticipants = partie.JoueursParticipants.ToList();

            JoueurPartie joueurCourant = partie.JoueursParticipants.ElementAt(0);
            List<De> listDe = joueurCourant.DesMain.ToList();

            if (partie.Sens)
            {
                for (int i = 0; i < listParticipants.Count - 1; i++)
                {
                    joueurCourant.DesMain = listParticipants.ElementAt(i + 1).DesMain;
                    joueurCourant = listParticipants.ElementAt(i + 1);
                }
                listParticipants.ElementAt(listParticipants.Count - 1).DesMain = listDe;

            }
            else
            {
                joueurCourant = partie.JoueursParticipants.ElementAt(listParticipants.Count - 1);
                listDe = joueurCourant.DesMain.ToList();

                for (int i = listParticipants.Count; i > 0; i--)
                {
                    joueurCourant.DesMain = listParticipants.ElementAt(i - 1).DesMain;
                    joueurCourant = listParticipants.ElementAt(i - 1);
                }
                listParticipants.ElementAt(listParticipants.Count - 1).DesMain = listDe;

            }

            dbcontext.SaveChanges();

        }

        public JoueurPartieDto next()
        {
            int ordreJoueur = partie.JoueurCourant.OrdreJoueur;
            int nbJoueur = partie.JoueursParticipants.Count;
            JoueurPartie joueurPartie = null;

            int i = partie.JoueurCourant.OrdreJoueur;
            if (partie.Sens)
            {
                if (nbJoueur == ordreJoueur)
                {
                    ordreJoueur = 1;
                    joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                    where jp.OrdreJoueur.Equals(ordreJoueur)
                                    select jp).FirstOrDefault();
                }
                else
                {
                    ordreJoueur++;
                    joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                    where jp.OrdreJoueur.Equals(ordreJoueur)
                                    select jp).FirstOrDefault();
                }
            }
            else
            {
                if (ordreJoueur == 1)
                {
                    ordreJoueur = nbJoueur;
                    joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                    where jp.OrdreJoueur.Equals(ordreJoueur)
                                    select jp).FirstOrDefault();
                }
                else
                {
                    ordreJoueur--;
                    joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                    where jp.OrdreJoueur.Equals(ordreJoueur)
                                    select jp).FirstOrDefault();
                }
            }



            partie.JoueurCourant = joueurPartie;
            dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();
            return BizToDto.ToJoueurPartieDto(joueurPartie);
        }

        public void rejouerEtChangementDeSens(int IdJoueurPartie)
        {
            partie.Sens = !partie.Sens;
        }

        public void prendreUneCarteDUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            JoueurPartie joueurPartieCible = getJoueurPartie(IdJoueurPartieCible);


            List<Carte> list = joueurPartieCible.CartesMain.ToList();
            Random random = new Random();

            int rand = random.Next(list.Count);
            Carte carte = list.ElementAt(rand);
            joueurPartie.CartesMain.Add(carte);
            joueurPartieCible.CartesMain.Remove(carte);

            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(joueurPartieCible).State = System.Data.Entity.EntityState.Modified;

            dbcontext.SaveChanges();


        }

        public void donnerUnDeAUnJoueur(int IdJoueurPartie, int IdJoueurPartieCible)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);


            JoueurPartie joueurPartieCible = getJoueurPartie(IdJoueurPartieCible);


            De de = joueurPartie.DesMain.First();
            joueurPartieCible.DesMain.Add(de);
            joueurPartie.DesMain.Remove(de);
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(joueurPartieCible).State = System.Data.Entity.EntityState.Modified;

            dbcontext.SaveChanges();
        }

        public void ciblerJoueurQUUneCarte(int IdJoueurPartieCible, int IdCarte)
        {

            JoueurPartie joueurPartieCible = getJoueurPartie(IdJoueurPartieCible);

            int nbCarte = joueurPartieCible.CartesMain.Count;
            List<Carte> list = joueurPartieCible.CartesMain.ToList();
            foreach (Carte c in list)
            {
                if (c.Id == IdCarte)
                {
                    continue;
                }
                else
                {
                    jeterCartePoubelle(IdJoueurPartieCible, c.Id);
                }
            }


        }

        public void passeSonTour(int IdJoueurPartie, int IdJoueurPartieCible)
        {
            throw new NotImplementedException();
        }

        public void piocheTroisCartes(int IdJoueurPartie)
        {
            for (int i = 0; i < 3; i++)
            {
                piocherCarte(IdJoueurPartie);
            }
        }

        public void plusQueDeuxCartesPourLesAutres(int IdJoueurPartie, Dictionary<int, List<int>> dico)
        {
            List<JoueurPartie> listJoueurPartie = partie.JoueursParticipants.ToList();


            foreach (JoueurPartie joueurPartie in listJoueurPartie)
            {
                if (dico.ContainsKey(joueurPartie.Id))
                {


                    int nombreCarteJoueur = joueurPartie.CartesMain.Count;
                    List<int> list = dico[joueurPartie.Id];
                    if (nombreCarteJoueur <= 2)
                    {
                        continue;
                    }
                    if (nombreCarteJoueur == 3)
                    {
                        //enlever1
                        for (int i = 0; i < nombreCarteJoueur; i++)
                        {
                            Carte carte = joueurPartie.CartesMain.ElementAt(i);
                            if (carte.Id != list.ElementAt(0) && carte.Id != list.ElementAt(1))
                            {
                                jeterCartePoubelle(joueurPartie.Id, carte.Id);
                                break;
                            }
                        }

                    }
                    else
                    {
                        //enlever2ou+
                        for (int i = 0; i < nombreCarteJoueur; i++)
                        {
                            Carte carte = joueurPartie.CartesMain.ElementAt(i);
                            if (carte.Id != list.ElementAt(0) && carte.Id != list.ElementAt(1))
                            {
                                jeterCartePoubelle(joueurPartie.Id, carte.Id);
                            }
                        }
                    }


                }
            }


        }

        public void jeterCartePoubelle(int IdJoueurPartie, int IdCarte)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            Carte carte = (from Carte ca in dbcontext.Cartes
                           where ca.Id.Equals(IdCarte)
                           select ca).FirstOrDefault();


            joueurPartie.CartesMain.Remove(carte);
            partie.CartesPoubelle.Add(carte);

            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();

        }

        public JoueurPartie getJoueurPartie(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = (from JoueurPartie jp in dbcontext.JoueurParties
                                         where jp.Id.Equals(IdJoueurPartie)
                                         select jp).FirstOrDefault();
            return joueurPartie;
        }

        public JoueurPartieDto quitterPartie(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            int nbJoueurs = partie.JoueursParticipants.Count;
        

            List<Carte> listeCarte = joueurPartie.CartesMain.ToList();
            List<De> listeDe = joueurPartie.DesMain.ToList();

            foreach (Carte c in listeCarte)
            {
                joueurPartie.CartesMain.Remove(c);
                partie.CartesPoubelle.Add(c);
            }

            foreach (De d in listeDe)
            {
                joueurPartie.DesMain.Remove(d);
            }



            //Si dernier
            if (joueurPartie.OrdreJoueur == nbJoueurs)
            {
                partie.JoueursParticipants.Remove(joueurPartie);
            }
            //Si premier
            else if (joueurPartie.OrdreJoueur == 1)
            {
                int ordreJoueur;
                for (int i = 1; i < nbJoueurs; i++)
                {
                    ordreJoueur = partie.JoueursParticipants.ElementAt(i).OrdreJoueur;
                    partie.JoueursParticipants.ElementAt(i).OrdreJoueur = ordreJoueur - 1;
                }
                partie.JoueursParticipants.Remove(joueurPartie);
            }
            //sinon milieu de list
            else
            {
                int ordreJoueur;
                for (int i = joueurPartie.OrdreJoueur + 1; i < nbJoueurs; i++)
                {
                    ordreJoueur = partie.JoueursParticipants.ElementAt(i).OrdreJoueur;
                    partie.JoueursParticipants.ElementAt(i).OrdreJoueur = ordreJoueur - 1;
                }
                partie.JoueursParticipants.Remove(joueurPartie);
            }
            dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.Entry(joueurPartie).State = System.Data.Entity.EntityState.Modified;
            dbcontext.SaveChanges();


            

            return BizToDto.ToJoueurPartieDto(joueurPartie);

        }

        public JoueurPartieDto vainqueurParForfait()
        {
            //TODO verifier ElementAt(0)
            if (partie.JoueursParticipants.Count == 1)
            {
                JoueurPartie joueurVainqueur = partie.JoueursParticipants.ElementAt(0);
                return BizToDto.ToJoueurPartieDto(joueurVainqueur);

            }
            return null;
        }
        public JoueurPartieDto vainqueur(int IdJoueurPartie)
        {
            JoueurPartie joueurPartie = getJoueurPartie(IdJoueurPartie);

            if (joueurPartie.DesMain.Count == 0)
            {
                return BizToDto.ToJoueurPartieDto(joueurPartie);
            }

            return null;
        }
    }
}
