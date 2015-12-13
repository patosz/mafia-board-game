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
        private UccJoueurRef.GestionJoueurClient uccJoueur = new UccJoueurRef.GestionJoueurClient();

        [HttpPost]
        public ActionResult Inscrire(string pseudo, string mdp)
        {
            JoueurDto jDto = uccJoueur.ConnexionJoueur(pseudo, mdp);

            if (jDto == null)
                return RedirectToAction("Index", new { controller = "Index" });

            //Session["username"] = jDto.Pseudo;

            TempData.Add("myUser", jDto);

            return RedirectToAction("Index", "Partie",new { pseudo = jDto.Pseudo });
        }
    }
}