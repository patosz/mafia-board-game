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
            proxy.InscriptionJoueur("Milenko5", "Milenko2");

            ServiceReference2.GestionPartieClient proxy2 = new ServiceReference2.GestionPartieClient();
            proxy2.CreerPartie("fifa","Milenko");
        }
    }
}
