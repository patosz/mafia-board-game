using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Dto;

namespace UI.Controllers
{
    public class PartieController : Controller
    {
        private UccPartieRef.GestionPartieClient UccPartie = new UccPartieRef.GestionPartieClient();
        private UccJoueurRef.GestionJoueurClient UccJoueur = new UccJoueurRef.GestionJoueurClient();

        // GET: Partie
        public ActionResult Index(String pseudo)
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", new { controller = "Index" });

            return View((JoueurDto)Session["user"]);
        }

        public ActionResult Creer()
        {
            return PartialView("CreerForm");
        }

        [HttpPost]
        public ActionResult Creer(string nomPartie)
        {
            string pseudo = ((JoueurDto)Session["user"]).Pseudo;
            bool res = UccPartie.CreerPartie(nomPartie, pseudo);
            if (res)
            {
                //TODO need méthode pour avoir le nom/id de la partie
                //Session["partie"] = UccPartie.GetPartie();
                return RedirectToAction("WaitForStart");
            }
            else
            {
                TempData["error"] = "Un problème est servenu lors de la création de la partie";
                return RedirectToAction("Creer");
            }
        }

        public ViewResult WaitForStart()
        {
            //TODO passer le nom de la partie à la vue
            return View();   
        }

        public ViewResult Rejoindre(string pseudo)
        {
            return View();
        }


        public ActionResult VoirParties()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            List<PartieDto> parties = new List<PartieDto>();
            //= UccJoueur.GetPartiesJouees(j.Pseudo);
            return PartialView("VoirParties", parties);
        }
    }
}