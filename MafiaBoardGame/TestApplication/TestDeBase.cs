using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication
{
    public class TestDeBase
    {
        public TestDeBase()
        {
            ServiceReference1.GestionJoueurClient joueurClient = new ServiceReference1.GestionJoueurClient();
            ServiceReference2.GestionPartieClient partieClient = new ServiceReference2.GestionPartieClient();
            string joueur1 = "pierre";
            string joueur2 = "paul";
            string joueur3 = "jacques";

            string mdp = "qwertz";
            string partie = "mafia";

            //Test inscriptionJoueur 
            bool inscription = joueurClient.InscriptionJoueur(joueur1, mdp);
            if (inscription)
                Console.WriteLine("Joueur Inscrit : " + joueur1);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur1);

            inscription = joueurClient.InscriptionJoueur(joueur2, mdp);
            if (inscription)
                Console.WriteLine("Joueur Inscrit : " + joueur2);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur2);
            inscription = joueurClient.InscriptionJoueur(joueur3, mdp);
            if (inscription)
                Console.WriteLine("Joueur Inscrit : " + joueur3);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur3);


            //Test connexionJoueur 
            if (joueurClient.ConnexionJoueur(joueur1, mdp) == null)
                Console.WriteLine("Connexion de " + joueur1 + " fail");
            else
                Console.WriteLine("Joueur " + joueur1 + " connecté!");
            if (joueurClient.ConnexionJoueur(joueur2, mdp) == null)
                Console.WriteLine("Connexion de " + joueur2 + " fail");
            else
                Console.WriteLine("Joueur " + joueur2 + " connecté!");

            if (joueurClient.ConnexionJoueur(joueur3, mdp) == null)
                Console.WriteLine("Connexion de " + joueur3 + " fail");
            else
                Console.WriteLine("Joueur " + joueur3 + " connecté!");


            

            //Test creerPartie
            PartieDto partieDto = partieClient.CreerPartie(partie, joueur1);
            if (partieDto != null)
                Console.WriteLine("Partie crée correctement : " + partie + " par " + joueur1);
            else
                Console.WriteLine("Echec création de partie");


            //Test rejoindrePartie
            PartieDto rejoindre = partieClient.RejoindrePartie(joueur2);
            if (rejoindre!=null)
                Console.WriteLine("Rejoindre OK : " + joueur2);
            else
                Console.WriteLine("Rejoindre KO");
            rejoindre = partieClient.RejoindrePartie(joueur3);
            if (rejoindre!=null)
                Console.WriteLine("Rejoindre OK : " + joueur3);
            else
                Console.WriteLine("Rejoindre KO");



            //Test VoirPartie
            List<PartieDto> list = partieClient.VoirPartie(joueur2).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Partie n° " + i + " : " + list.ElementAt(i).Nom);
            }

            //Test lancerPartie + getJoueurDto
            PartieDto pDto = partieClient.LancerPartie();
            Console.WriteLine(pDto.Nom + " " + pDto.DateHeureCreation);
            Console.WriteLine("ID : " + partieDto.JoueurCourant.Id);
            Console.WriteLine("Pseudo : " + partieClient.getJoueurDto(partieDto.JoueurCourant.Id).Pseudo);


            Console.ReadLine();
        }
    }

}
