using Domain.Dal;
using Domain.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.GestionJoueurClient joueurClient = new ServiceReference1.GestionJoueurClient();
            string joueur1 = "gio";
            string joueur2 = "gary";
            string mdp = "ee";
            string partie = "love";

            //Test inscriptionJoueur 
            bool inscription = joueurClient.InscriptionJoueur(joueur1,mdp);
            if (inscription)
                Console.WriteLine("Joueur Inscrit : " + joueur1);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur1);

            inscription = joueurClient.InscriptionJoueur(joueur2, mdp);
            if (inscription)
                Console.WriteLine("Joueur Inscrit : " + joueur2);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur2);

            //Test connexionJoueur 
            if (joueurClient.ConnexionJoueur(joueur2, mdp) == null)
                Console.WriteLine("Connexion de "+joueur2+" fail");
            else
                Console.WriteLine("Joueur "+joueur2+" connecté!");

            ServiceReference2.GestionPartieClient partieClient = new ServiceReference2.GestionPartieClient();

            //Test creerPartie
            PartieDto partieDto = partieClient.CreerPartie(partie,joueur1);
            if (partieDto != null)
                Console.WriteLine("Partie crée correctement : " + partie + " par " + joueur1);
            else
                Console.WriteLine("Echec création de partie");

            //Test rejoindrePartie
            bool rejoindre = partieClient.RejoindrePartie(joueur2);
            if (rejoindre)
                Console.WriteLine("Rejoindre OK : " + joueur2);
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
            Console.WriteLine("ID : "+partieDto.JoueurCourant.Id);
            Console.WriteLine("Pseudo : "+partieClient.getJoueurDto(partieDto.JoueurCourant.Id).Pseudo);


            //Test getListCartesDto
            List<CarteDto> listeCarte = partieClient.getListCartesDto(partieDto.JoueurCourant.Id).ToList();

            for (int i = 0; i < listeCarte.Count; i++)
            {
                Console.WriteLine("Carte ID : " + listeCarte.ElementAt(i).Id + ", effet : " + listeCarte.ElementAt(i).Effet+", cout : "+ listeCarte.ElementAt(i).Cout);
            }


            //Test LancerDe
            //TODO regarder le random au niveau des des (classe PartielDe)
            List<DeDto> listeDe = partieClient.lancerDes(partieDto.JoueurCourant.Id).ToList();

            for (int i = 0; i < listeDe.Count; i++)
            {
                Console.WriteLine("De debut ID : " + listeDe.ElementAt(i).Id + ", valeur : " + listeDe.ElementAt(i).Valeur + "\n");
            }

             for (int i = 0; i < listeDe.Count; i++)
            {
                Console.WriteLine("De ACTION ID : " + listeDe.ElementAt(i).Id + ", valeur : " + listeDe.ElementAt(i).Valeur+"\n");

                //Si pioche
                if (listeDe.ElementAt(i).Valeur.Equals("P"))
                {
                    Console.WriteLine("Pioche carte");
                    CarteDto carte =  partieClient.piocherCarte(partieDto.JoueurCourant.Id);

                    List<CarteDto> NewlisteCarte = partieClient.getListCartesDto(partieDto.JoueurCourant.Id).ToList();
                    //MAJ des cartes de la main
                    for (int j = 0; j < NewlisteCarte.Count; j++)
                    {
                        Console.WriteLine("MAJ de la main, carte ID : " + NewlisteCarte.ElementAt(j).Id + ", effet : " + NewlisteCarte.ElementAt(j).Effet + ", cout : " + NewlisteCarte.ElementAt(j).Cout);
                    }
                }
                //Donne un de
                else if (listeDe.ElementAt(i).Valeur.Equals("D"))
                {
                    Console.WriteLine("Donne de");
                    bool donnnerDe = partieClient.donnerDe(partieDto.JoueurCourant.Id,2);
                    if (donnnerDe)
                    {
                        Console.WriteLine("Donnation OK");
                        List<DeDto> NewlisteDe = partieClient.getListDesDto(partieDto.JoueurCourant.Id).ToList();
                        for (int j = 0; j < NewlisteDe.Count; j++)
                        {
                            Console.WriteLine("New De , ID : " + NewlisteDe.ElementAt(j).Id + ", valeur : " + NewlisteDe.ElementAt(j).Valeur);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Donnation KO");
                    }
                }
               else
                {
                    Console.WriteLine("Symbole Mafia \n");
                    partieClient.supprimerUnDe(partieDto.JoueurCourant.Id,listeDe.ElementAt(i).Id);

                    //MAJ des des
                    List<DeDto> NewlisteDe = partieClient.getListDesDto(partieDto.JoueurCourant.Id).ToList();
                    for (int j = 0; j < NewlisteDe.Count; j++)
                    {
                        Console.WriteLine("New De , ID : " + NewlisteDe.ElementAt(j).Id + ", valeur : " + NewlisteDe.ElementAt(j).Valeur);
                    }
                }
            }


            




            //Test next
            /*JoueurPartieDto pjd = partieClient.next();
            Console.WriteLine(""+pjd.Id);*/

            

            Console.ReadLine();
        }
    }
}
