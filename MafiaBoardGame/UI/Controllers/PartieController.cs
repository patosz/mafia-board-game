using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Dto;
using UI.Models;
using System.Web.UI;

namespace UI.Controllers
{
    public class PartieController : Controller
    {

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
            PartieDto part = UCCPartie.Instance.CreerPartie(nomPartie, pseudo);
            if (part != null)
            {
                //TODO lancer timer

                Session["partie"] = part.Id;
                return RedirectToAction("WaitForStart", part);
            }
            else
            {
                TempData["error"] = "Un problème est servenu lors de la création de la partie";
                return RedirectToAction("Creer");
            }
        }

        public ViewResult WaitForStart(PartieDto partie)
        {
            LoadScreenModel model = new LoadScreenModel();
            model.Partie = partie;
            model.Participants = UCCPartie.Instance.getListJoueurParticipantsDto(partie.Id).ToList();
            return View(model);
        }


        public ActionResult CheckPartieLancee(){
            JoueurDto jd = (JoueurDto)Session["user"];
            GameStateDto gs = UCCPartie.Instance.getGameState(jd.Pseudo);
            if (gs.Etat == 1)
            {
                return RedirectToAction("RefreshLoadScreen");
            }
            else
            {
                return RedirectToAction("Index", new { controller = "Plateau"});
            }
        }


        public PartialViewResult RefreshLoadScreen(List<JoueurPartieDto> liste)
        {
            if (liste == null)
            {
                int idPartie = (int)Session["partie"];
                liste = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();
            }
            return PartialView(liste);
        }

        public ActionResult Rejoindre()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            PartieDto p = UCCPartie.Instance.RejoindrePartie(j.Pseudo);
            if (p != null)
            {
                Session["partie"] = p.Id;
                return RedirectToAction("WaitForStart", p);
            }
            else
            {
                TempData["error"] = "Un problème est servenu lors de la tentative de rejoindre la partie";
                return RedirectToAction("VoirPartiesDisponibles");
            }
        }


        public ActionResult VoirPartiesJouees()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            List<PartieDto> parties = new List<PartieDto>();
            //TODO recevoir une liste = UCCJoueur.Instance.GetPartiesJouees(j.Pseudo);
            return PartialView("VoirPartiesJouees", parties);
        }

        public ActionResult VoirPartiesDisponibles()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            List<PartieDto> parties = new List<PartieDto>();
            //TODO recevoir une  liste = UCCJoueur.Instance.GetPartiesJouees(j.Pseudo);
            return PartialView("VoirPartiesDisponibles", parties);
        }
    }
}