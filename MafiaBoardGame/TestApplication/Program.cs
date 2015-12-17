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
            TestDeBase testDeBase = new TestDeBase();

            /*
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
                    //partieClient.supprimerUnDe(partieDto.JoueurCourant.Id);
                    //partieClient.prendreUneCarteDUnJoueur(partieDto.JoueurCourant.Id,3);
                    //partieClient.donnerUnDeAUnJoueur(partieDto.JoueurCourant.Id, 3);
                    Dictionary<int, List<int>> dico = new Dictionary<int, List<int>>();
                    List<int> listJoueur2 = new List<int>();
                    listJoueur2.Add(4);
                    listJoueur2.Add(5);

                    List<int> listJoueur3 = new List<int>();
                    listJoueur3.Add(7);
                    listJoueur3.Add(8);

                    dico.Add(2,listJoueur2);
                    dico.Add(3, listJoueur3);


                    partieClient.plusQueDeuxCartesPourLesAutres(1, dico);



                    List<CarteDto> NewlisteCarte = partieClient.getListCartesDto(partieDto.JoueurCourant.Id).ToList();
                    //MAJ des cartes de la main
                    for (int j = 0; j < NewlisteCarte.Count; j++)
                    {
                        Console.WriteLine("MAJ de la main, carte ID : " + NewlisteCarte.ElementAt(j).Id + ", effet : " + NewlisteCarte.ElementAt(j).Effet + ", cout : " + NewlisteCarte.ElementAt(j).Cout);
                    }
                }
            }




             //Test changement de sens
            Console.WriteLine("TEST changement de sens");
            partieClient.rejouerEtChangementDeSens(partieDto.JoueurCourant.Id);

            //Test next
            Console.WriteLine("TEST next()");
            JoueurPartieDto pjd = partieClient.next();
            Console.WriteLine("Id joueur : "+pjd.Id);
            pjd = partieClient.next();
            Console.WriteLine("Id joueur suivant : " + pjd.Id);*/

            //Quitter partie
            /*partieClient.quitterPartie(1);
            partieClient.supprimerUnDe(3);
            partieClient.supprimerUnDe(3);
            partieClient.supprimerUnDe(3);
            partieClient.supprimerUnDe(3);
            partieClient.vainqueur(3);*/


            /*Console.WriteLine("Creer 2eme partie");

            PartieDto partieDto1 = partieClient.CreerPartie(partie, joueur4);
            if (partieDto != null)
                Console.WriteLine("Partie crée correctement : " + partie + " par " + joueur4);
            else
                Console.WriteLine("Echec création de partie");

            Console.WriteLine("Heure de creation : " + partieDto1.DateHeureCreation);*/




            Console.ReadLine();
        }
    }
}
