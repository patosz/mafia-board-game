using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class JoueurController : Controller
    {
        private UCCJoueurRef.GestionJoueurClient uccJoueur;

        public JoueurController(UCCJoueurRef.GestionJoueurClient uccJoueur)
        {
            this.uccJoueur = uccJoueur;
        }

        [HttpPost]
        public ActionResult Inscrire(string pseudo, string mdp)
        {

            //JoueurClient jc = uccJoueur.InscriptionJoueur(pseudo, mdp);
            return RedirectToAction("Partie",new { controller = "Index" });
        }
    }
}