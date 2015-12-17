using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Dto;
using UI.Models;

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
            PartieDto part = UccPartie.CreerPartie(nomPartie, pseudo);
            if (part != null)
            {
                //TODO lancer timer
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
            List<JoueurPartieDto> participants = UccPartie.getListJoueurParticipantsDto(partie.Id).ToList();
            foreach(JoueurPartieDto jp in participants){
           // model.Participants;// = ;
            }
            return View(model);
        }

        public PartialViewResult RefreshLoadScreen(PartieDto p)
        {
            return PartialView(UccPartie.getListJoueurParticipantsDto(p.Id).ToList());
        }

        public ActionResult Rejoindre(string pseudo)
        {
            //TODO ajouter un param avec l'id de la partie à rejondre
            bool res = true;// UccPartie.RejoindrePartie(pseudo);
            if (res)
            {
                return RedirectToAction("WaitForStart");
            }
            else
            {
                TempData["error"] = "Un problème est servenu lors de la création de la partie";
                return RedirectToAction("VoirPartiesDisponibles");
            }
        }


        public ActionResult VoirPartiesJouees()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            List<PartieDto> parties = new List<PartieDto>();
            //TODO recevoir une liste = UccJoueur.GetPartiesJouees(j.Pseudo);
            return PartialView("VoirPartiesJouees", parties);
        }

        public ActionResult VoirPartiesDisponibles()
        {
            JoueurDto j = (JoueurDto)Session["user"];
            List<PartieDto> parties = new List<PartieDto>();
            //TODO recevoir une  liste = UccJoueur.GetPartiesJouees(j.Pseudo);
            return PartialView("VoirPartiesDisponibles", parties);
        }
    }
}