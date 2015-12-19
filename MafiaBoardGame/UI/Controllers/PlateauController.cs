using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;
using System.Web.Services;
using UI.Models;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class PlateauController : Controller
    {
        // GET: Plateau
        public ActionResult Index(string nomPartie = "Partie aléatoire")
        {

            //TODO ajouter système check partie invalide demandée

            //TODO ajouter checks sur l'état de la partie !!!

            JoueurDto jdt = (JoueurDto)Session["user"];
            int idPartie = (int)Session["partie"];

            List<JoueurPartieDto> participants = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();

            ModelPlateau plateau = new ModelPlateau();
            plateau.Adversaires = new List<AdversaireModel>();

            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);

            plateau.Etat = p.Etat;
            plateau.JoueurCourant = p.JoueurCourant.Joueur;
            plateau.DerniereCarteJouee = UCCPartie.Instance.getLastCartePoubelle();

            foreach (JoueurPartieDto jp in participants)
            {
                AdversaireModel adv = new AdversaireModel();
                adv.Pseudo = jp.Joueur.Pseudo;
                adv.Des = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                adv.Cartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                if (adv.Pseudo.Equals(jdt.Pseudo))
                {
                    plateau.MesDes = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.DesCourant = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.MesCartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                }
                plateau.Adversaires.Add(adv);
            }

            ViewData["partie"] = nomPartie;
            return View(plateau);
        }

        public PartialViewResult RefreshPlateau(string nomPartie = "Partie aléatoire")
        {
            //TODO ajouter système check partie invalide demandée

            //TODO ajouter checks sur l'état de la partie !!!

            JoueurDto jdt = (JoueurDto)Session["user"];
            int idPartie = (int)Session["partie"];

            List<JoueurPartieDto> participants = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();

            ModelPlateau plateau = new ModelPlateau();
            plateau.Adversaires = new List<AdversaireModel>();

            PartieDto p = UCCPartie.Instance.getPartieDto(idPartie);

            plateau.Etat = p.Etat;
            plateau.JoueurCourant = p.JoueurCourant.Joueur;
            plateau.DerniereCarteJouee = UCCPartie.Instance.getLastCartePoubelle();

            foreach (JoueurPartieDto jp in participants)
            {
                AdversaireModel adv = new AdversaireModel();
                adv.Pseudo = jp.Joueur.Pseudo;
                adv.Des = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                adv.Cartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                if (adv.Pseudo.Equals(jdt.Pseudo))
                {
                    plateau.MesDes = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.DesCourant = UCCPartie.Instance.getListDesDto(jp.Id).ToList();
                    plateau.MesCartes = UCCPartie.Instance.getListCartesDto(jp.Id).ToList();
                }
                plateau.Adversaires.Add(adv);
            }

            ViewData["partie"] = nomPartie;
            return PartialView(plateau);
        }

        public ActionResult Index2(string nomPartie = "Test")
        {
            ViewData["partie"] = nomPartie;

            return View();
        }

        public ViewResult IndexTemplate()
        {
            return View();
        }

        [WebMethod]
        public ActionResult JouerCarte(string json = "")
        {
            if (json == "")
                return Json(new { success = false, res = "Prob param" }, JsonRequestBehavior.AllowGet);
            string sens = "";
            int cible = 0;
            string[] tab= json.Split(':');
            int typeCarte = int.Parse(tab[0]);
            int idCarte = int.Parse(tab[1]);
            if(tab[2] != "")
                cible = int.Parse(tab[2]);
            if(tab[3] != "")
                 sens = tab[3];
            int idPartie = (int)Session["partie"];
            int joueurPartie = UCCPartie.Instance.getPartieDto(idPartie).JoueurCourant.Id;
           
            CarteDto carteDto = UCCPartie.Instance.getCarteDto(idCarte);
            
            switch (typeCarte)
            {
                case 1:
                    //Supprimer 1 des
                    UCCPartie.Instance.supprimerUnDe(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 2:
                    //Donner des gauche ou droite
                    if (sens == "G")
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(false);
                    else
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(true);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 3:
                    //Supprimer 2 des
                    UCCPartie.Instance.supprimerDeuxDes(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 4:
                    //Donner 1 dé
                    UCCPartie.Instance.donnerUnDeAUnJoueur(joueurPartie, cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 5:
                    //Prendre 1 carte au joueur de mon choix
                    UCCPartie.Instance.prendreUneCarteDUnJoueur(joueurPartie, cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 6:
                    //Joueur de mon choix n'a plus qu'une carte
                    UCCPartie.Instance.ciblerJoueurQUUneCarte(cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 7:
                    //Piocher 3 cartes
                    UCCPartie.Instance.piocheTroisCartes(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 8:
                    //Tous les joueurs sauf moi n'ont plus que 2 cartes
                    UCCPartie.Instance.plusQueDeuxCartesPourLesAutres(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 9:
                    //Joueur de mon choix passe son tour

                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                case 10:
                    //Rejouer et changer de tour
                    UCCPartie.Instance.rejouerEtChangementDeSens(joueurPartie);
                    UCCPartie.Instance.jeterCartePoubelle(joueurPartie, idCarte);
                    break;
                default: return Json(new { success = false, res = "Prob Switch Case" }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { success = true, res = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}
