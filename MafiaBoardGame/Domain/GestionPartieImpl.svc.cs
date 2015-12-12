using Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public bool CreerPartie(String nomPartie, String nomJoueur)
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
                partie = new Partie (nomPartie);
                partie.etat = (int)Partie.ETAT.INSCRIPTION;
                // relation PartieJoueur 0..1 sinon EF demandera une référence joueur pour ce champ
                //partie.JoueurCourant = joueur;

                try
                {

                    JoueurPartie joueurPartie = new JoueurPartie();
                    //Joueur
                    joueur.JoueurPartie.Add(joueurPartie);
                    joueur.Partie.Add(partie);
                    //JoueurPartie
                    joueurPartie.Partie = partie;
                    joueurPartie.Joueur = joueur;
                    joueurPartie.JoueurId = joueur.Id;

                    //Partie
                    partie.JoueurPartie.Add(joueurPartie);
                    partie.JoueurCourantPartie = joueurPartie;
                    partie.JoueurId = joueur.Id;
                    //JoueurPartie
                    joueurPartie.OrdreJoueurs = partie.JoueurPartie.Count;
                    joueurPartie.JoueurId = joueur.Id;

                    dbcontext.JoueurPartieSet.Add(joueurPartie);
                   // dbcontext.SaveChanges();
                    dbcontext.JoueurSet.Add(joueur);
                   // dbcontext.SaveChanges();
                  //  dbcontext.Entry(joueur).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.PartieSet.Add(partie);


                    dbcontext.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;


                }
            }
            return true;
        }

        public bool RejoindrePartie(string pseudo)
        {
            return false;
        }
    }
}
