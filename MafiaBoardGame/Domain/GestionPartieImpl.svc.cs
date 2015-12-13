﻿using Domain.Dto;
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
                joueurPartie.PartieCourant = partie;
                //joueurPartie.JoueurId = joueur.Id;


                //Partie
                partie.JoueursParticipants.Add(joueurPartie);
                partie.JoueurCourant = joueurPartie;
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
            str += "Joueur Courant :" + partie.JoueurCourant.Joueur.Pseudo + "\n";
            str += "Nb de participants : " + partie.JoueursParticipants.Count + "\n";
            return str;
        }

        //on donne quoi le string un objet??
        public bool RejoindrePartie(string pseudo)
        {
            
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
                joueur.PartiesJouees.Add(joueurPartie);
                //est ce que je dois vraiment mettre la partie courante?
                joueurPartie.Partie = partie;
                joueurPartie.Joueur = joueur;
                joueurPartie.PartieCourant = partie;

                //est ce que je dois vraiment mettre la JoueurCourant courante?
                partie.JoueursParticipants.Add(joueurPartie);
                partie.JoueurCourant = joueurPartie;

                joueurPartie.OrdreJoueur = partie.JoueursParticipants.Count;

                dbcontext.JoueurParties.Add(joueurPartie);
                //dbcontext.Joueurs.Add(joueur);
                dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                dbcontext.Entry(partie).State = System.Data.Entity.EntityState.Modified;
                //dbcontext.Parties.Add(partie);


                dbcontext.SaveChanges();
            }

                return true;
        }
    }
}