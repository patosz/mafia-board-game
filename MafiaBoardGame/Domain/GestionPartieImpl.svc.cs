using Domain.Model;
using System;
using System.Collections.Generic;
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
        public GestionPartieImpl()
        {
            dbcontext = new ModelContainer();
        }
        public bool CommencerPartie()
        {
            throw new NotImplementedException();
        }

        public bool CreerPartie(String nomPartie,String nomJoueur)
        {
            Joueur joueur = (from Joueur j in dbcontext.JoueurSet
                           where j.Pseudo.Equals(nomJoueur)
                           select j).FirstOrDefault();
            if (joueur == null)
            {
                //erreur a géré 
                return false;
            }
            if (partie != null && (int)partie.etat == (int)Partie.ETAT.EN_COURS)
                return false;
            if (partie == null || (int)partie.etat == (int)Partie.ETAT.TERMINE)
            {
                partie = new Partie(nomPartie);
                partie.etat = (int)Partie.ETAT.INSCRIPTION;
                // relation PartieJoueur 0..1 sinon EF demandera une référence joueur pour ce champ
                //partie.JoueurCourant = joueur;
                


                JoueurPartie joueurPartie = new JoueurPartie();
                //Joueur
                joueur.JoueurPartie.Add(joueurPartie);
                joueur.Partie.Add(partie);
                //JoueurPartie
                joueurPartie.Partie = partie;
                joueurPartie.Joueur = joueur;

                //Partie
                partie.JoueurPartie.Add(joueurPartie);
                //JoueurPartie
                joueurPartie.OrdreJoueurs = partie.JoueurPartie.Count;

                dbcontext.JoueurPartieSet.Add(joueurPartie);
                dbcontext.JoueurSet.Add(joueur);
                dbcontext.PartieSet.Add(partie);
                dbcontext.SaveChanges();

            }
            return true;
        }

        public bool RejoindrePartie(string pseudo)
        {
            return false;
        }
    }
}
