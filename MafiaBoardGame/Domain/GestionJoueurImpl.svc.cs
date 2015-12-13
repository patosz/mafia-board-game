using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain
{
    public class GestionJoueurImpl : IGestionJoueur
    {

        private static ModelContainer dbcontext;
        public GestionJoueurImpl()
        {
            dbcontext = new ModelContainer();
        }
        public bool InscriptionJoueur(string pseudo, string mdp)
        {
            Joueur joueur;
            Joueur temp = (from Joueur j in dbcontext.Joueurs
                           where j.Pseudo.Equals(pseudo)
                           select j).FirstOrDefault();
            if (temp == null)
            {
                joueur = new Joueur();
                joueur.Pseudo = pseudo;
                joueur.Mdp = mdp;
                dbcontext.Joueurs.Add(joueur);
                dbcontext.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ConnexionJoueur(string pseudo, string mdp)
        {
            
            Joueur joueur = (from Joueur j in dbcontext.Joueurs
                           where j.Pseudo.Equals(pseudo)
                           select j).FirstOrDefault();
            if (joueur == null)
            {
                
                return false;
            }
            return true;
        }
    }
}