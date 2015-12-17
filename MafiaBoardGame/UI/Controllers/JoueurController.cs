using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Controllers;

namespace UI.Controllers
{
    public class JoueurController : Controller
    {
        
        [HttpPost]
        public ActionResult LogIn(string pseudo, string mdp)
        {
            JoueurDto jDto = UCCJoueur.Instance.ConnexionJoueur(pseudo, mdp);

            if (jDto == null)
            {
                TempData["error"] = "Erreur de login ou mot de passe";
                return RedirectToAction("Index", new { controller = "Index" });
            }

            Session["user"] = jDto;

            return RedirectToAction("Index", "Partie");
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", new { controller = "Index" });
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        //TODO modifier pour correspondre à la situation actuelle
        public ActionResult Register(JoueurDto j)
        {

            bool res = UCCJoueur.Instance.InscriptionJoueur(j.Pseudo, j.Mdp);
            if (!res)
            {
                ViewData["errorMessage"] = "Erreur lors de l'inscription du joueur";
                return View();
            }
            else {
                return RedirectToAction("ConfirmRegistration");
            }
        }

        public ViewResult ConfirmRegistration()
        {
            return View();
        }
    }
}