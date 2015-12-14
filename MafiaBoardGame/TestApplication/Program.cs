﻿using Domain.Dal;
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
            ServiceReference1.GestionJoueurClient proxy = new ServiceReference1.GestionJoueurClient();
            string joueur1 = "milene";
            string joueur2 = "patou";
            string mdp = "ee";
            string partie = "guerre";

            bool ok = proxy.InscriptionJoueur(joueur1,mdp);
            if (ok)
                Console.WriteLine("Joueur Inscrit : "+joueur1);
            else
                Console.WriteLine("Joueur Déjà Inscrit! " + joueur1);

            ok = proxy.InscriptionJoueur(joueur2, mdp);
            if (ok)
                Console.WriteLine("Joueur Inscrit : "+joueur2);
            else
                Console.WriteLine("Joueur Déjà Inscrit! : "+joueur2);

            if (proxy.ConnexionJoueur("milene", "ee") == null)
                Console.WriteLine("Connexion de milene fail");
            else
                Console.WriteLine("Joueur milene connecté!");


            ServiceReference2.GestionPartieClient proxy2 = new ServiceReference2.GestionPartieClient();
            ok = proxy2.CreerPartie(partie,joueur1);
            if (ok)
                Console.WriteLine("Partie crée correctement : "+partie+ " / "+joueur1);
            else
                Console.WriteLine("Echec création de partie");

            string str = proxy2.GetPartie();
            Console.WriteLine(str);

            ok = proxy2.RejoindrePartie(joueur2);
            if(ok)
                Console.WriteLine("Rejoindre OK : "+joueur2);
            else
                Console.WriteLine("Rejoindre KO hamdoulilah");

            List<PartieDto> list = proxy2.VoirPartie(joueur2).ToList();

            for (int i = 0; i<list.Count;i++)
            {
                Console.WriteLine("Partie n° " + i + " : " + list.ElementAt(i).Nom);
            }


            
            Console.ReadLine();
        }
    }
}
