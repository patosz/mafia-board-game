using Domain.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Xml.Linq;

namespace Domain.Dal
{
    public class Parseur
    {
        //Load xml
        private XDocument xdoc = XDocument.Load(HostingEnvironment.ApplicationPhysicalPath+"Xml/wazabi.xml");

        public List<Carte> loadCarte()
        {

            List<Carte> list = new List<Carte>();

            IEnumerable<XElement> cartes = from carte in xdoc.Descendants("carte") select carte;
            // Read cartes
            foreach (var carte in cartes)
            {
                int nombreCarte = int.Parse(carte.Attribute("nb").Value);

                for(int i = 0; i < nombreCarte; i++)
                {
                    list.Add(new Carte(int.Parse(carte.Attribute("codeEffet").Value), int.Parse(carte.Attribute("cout").Value), carte.Attribute("effet").Value, carte.Value));
                }

                
                //Console.WriteLine(carte);
            }
            return list;
        }
        public List<int> loadInfoCartes()
        {
            XElement cartes = (from xml2 in xdoc.Elements("wazabi")
                               select xml2).FirstOrDefault();

            List<int> list = new List<int>();
            
            list.Add(int.Parse(cartes.Attribute("nbCartesParJoueur").Value));
            list.Add(int.Parse(cartes.Attribute("nbCartesTotal").Value));
            list.Add(int.Parse(cartes.Attribute("minJoueurs").Value));
            list.Add(int.Parse(cartes.Attribute("maxJoueurs").Value));
            return list;
        }
    }
}