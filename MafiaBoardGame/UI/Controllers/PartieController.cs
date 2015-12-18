using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Domain.Dto;
using UI.Models;
using System.Text;
using System.Web.UI;

namespace UI.Controllers
{

    public class PartieController : Controller
    {
        private readonly int LANCER_PARTIE_TIMER_INTERVAL = 15;

        //infos timer : https://msdn.microsoft.com/en-us/library/system.timers.timer.elapsed%28v=vs.110%29.aspx


        //signature spécifique pour correspondre au delegate du ElapsedEventHandler
        private void TimerLancerPartieEcoule(object sender, EventArgs e)
        {
            LancerPartie();
        }

        // GET: Partie
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", new { controller = "Index" });

            ViewData["username"] = ((JoueurDto)Session["user"]).Pseudo;
            return View();
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
                Session["partie"] = part.Id;
                Session.Add("partieCreation", DateTime.Now);
                return RedirectToAction("WaitForStart", part);
            }
            else
            {
                TempData["error"] = "Un problème est servenu lors de la création de la partie";
                return RedirectToAction("Creer");
            }
        }

        public void LancerPartie()
        {
            int idPartie = (int)Session["partie"];
            int NbJoueurs = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).Length;
            if (NbJoueurs == 1)
            {
                UCCPartie.Instance.annuler(idPartie);
                TempData["error"] = "Pas assez de joueurs. Partie annulée.";
                RedirectToAction("Index");
                return;
            }

            PartieDto p = UCCPartie.Instance.LancerPartie();
            if (p == null)
            {
                TempData["error"] = "Un problème est servenu lors du lancement de la partie";
                RedirectToAction("Index");
                return;
            }

            //return RedirectToAction("Index", "Plateau", p.Nom);
        }

        public ViewResult WaitForStart(PartieDto partie)
        {
            LoadScreenModel model = new LoadScreenModel();
            model.Partie = partie;
            model.Participants = UCCPartie.Instance.getListJoueurParticipantsDto(partie.Id).ToList();
            return View(model);
        }


        public PartialViewResult RefreshLoadScreen()
        {
            string status = "inscription";
            int idPartie = (int)Session["partie"];
            if (Session["partieCreation"] != null)
            {
                DateTime partieCreation = (DateTime)Session["partieCreation"];
                TimeSpan ts = DateTime.Now.Subtract(partieCreation);
                if (ts.TotalSeconds >= LANCER_PARTIE_TIMER_INTERVAL)
                {
                    LancerPartie();
                    status = "coucou";
                }
            }
            else {
                if (UCCPartie.Instance.getGameState(((JoueurDto)Session["user"]).Pseudo).Etat != (int)ETAT_PARTIE.INSCRIPTION)
                {
                    status = "plateau";
                }
            }

            ViewBag.status = status;
            return PartialView(UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList());
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
                TempData["error"] = "Impossible de rejoindre la partie en cours";
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

    //comment to push sync
}