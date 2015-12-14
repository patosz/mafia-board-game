using Domain.Dal;
using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Domain.Model
{
    public partial class Partie
    {
        public enum ETAT { INSCRIPTION = 0, EN_COURS = 1, TERMINE = 2 };
        public ETAT etat { get; set; }
        private int nbCartesParJoueur
        {
            get; set;
        }
        private int nbCartesTotal
        {
            get; set;
        }
        public int minJoueurs
        {
            get; set;
        }
        public int maxJoueur
        {
            get; set;
        }
        private Parseur parseur=new Parseur();

        private static Random rng = new Random();
        //ajout du parametre String nom
        public Partie(String nom)
        {
            // ligne du contructeur généré
            
            this.JoueursParticipants = new HashSet<JoueurPartie>();
            this.CartesPioche = new List<Carte>();
            this.Nom = nom;
            this.Sens = true;
            this.DateHeureCreation = DateTime.Now;

            List<int> cartesInfo = parseur.loadInfoCartes();

            nbCartesParJoueur = cartesInfo.ElementAt(0);
            nbCartesTotal = cartesInfo.ElementAt(1);
            minJoueurs = cartesInfo.ElementAt(2);
            maxJoueur = cartesInfo.ElementAt(3);

            List<Carte> listeTypeCarte = parseur.loadCarte();
            this.CartesPioche = listeTypeCarte;

        }
      
        public bool CommencerPartie()
        {
            return true;
        }


        public void Shuffle<Carte>(IList<Carte> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Carte value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


    }
    
}