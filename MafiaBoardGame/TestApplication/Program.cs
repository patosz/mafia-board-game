using Domain.Dal;
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
            bool ok = proxy.InscriptionJoueur("bru", "gigi");
            if (ok)
                Console.WriteLine("Joueur Inscrit");
            else
                Console.WriteLine("Joueur Déjà Inscrit!");

            ServiceReference2.GestionPartieClient proxy2 = new ServiceReference2.GestionPartieClient();
            ok = proxy2.CreerPartie("bri","bru");
            if (ok)
                Console.WriteLine("Partie crée correctement :)");
            else
                Console.WriteLine("Echec création de partie");

           // string str = proxy2.GetPartie();

          //  Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
