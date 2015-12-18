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
            //UCCPartie.Instance.getGameState(jdt.Pseudo);
            JoueurDto jdt = (JoueurDto)Session["user"];
            int idPartie = (int)Session["partie"];

            List<JoueurPartieDto> participants = UCCPartie.Instance.getListJoueurParticipantsDto(idPartie).ToList();

            JoueurPartieDto jp = participants.First();

            ModelPlateau plateau = new ModelPlateau();
            PartieDto p = UCCPartie.Instance.getPartiedto(idPartie);


            plateau.Etat =;
            plateau.DerniereCarteJouee;
            plateau.Adversaires;
            plateau.JoueurCourant;
            plateau.MesCartes;
            plateau.MesDes;
        
            //defausse          - OK
            //acces a la pioche - OK
            //des joueurCourant - OK
            
            //joueursParticipants
            ////nbCartes adversaire
            ////nbDes adversaire






            //TODO ajouter système check partie invalide demandée

            //TODO ajouter checks sur l'état de la partie !!!

            ViewData["partie"] = nomPartie;
            return View(gs);
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
                return Json(new { success = false, message = "Problème param methode" }, JsonRequestBehavior.AllowGet);

            Dictionary<string, string> dataJq = (Dictionary<string,string>)JsonConvert.DeserializeObject(json);
            int idCarte = int.Parse(dataJq["carteId"]);
            int cible = int.Parse(dataJq["cible"]);
            int deChoisi = int.Parse(dataJq["deChoisi"]);
            string sens = dataJq["sensChoisi"];
            int joueur = int.Parse(dataJq["joueurCourant"]);

            CarteDto carteDto = UCCPartie.Instance.getCarteDto(idCarte);
            int typeCarte = carteDto.CodeEffet;
            switch (typeCarte)
            {
                case 1:
                    //Supprimer 1 des
                    UCCPartie.Instance.supprimerUnDe(joueur);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 2:
                    //Donner des gauche ou droite
                    if (sens == "G")
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(false);
                    else
                        UCCPartie.Instance.donnerDeAGaucheOuDroite(true);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 3:
                    //Supprimer 2 des
                    UCCPartie.Instance.supprimerDeuxDes(joueur);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 4:
                    //Donner 1 dé
                    UCCPartie.Instance.donnerUnDeAUnJoueur(joueur, deChoisi);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 5:
                    //Prendre 1 carte au joueur de mon choix
                    UCCPartie.Instance.prendreUneCarteDUnJoueur(joueur, cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 6:
                    //Joueur de mon choix n'a plus qu'une carte
                    UCCPartie.Instance.ciblerJoueurQUUneCarte(cible);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 7:
                    //Piocher 3 cartes
                    UCCPartie.Instance.piocheTroisCartes(joueur);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 8:
                    //Tous les joueurs sauf moi n'ont plus que 2 cartes
                    UCCPartie.Instance.plusQueDeuxCartesPourLesAutres(joueur);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 9:
                    //Joueur de mon choix passe son tour

                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 10:
                    //Rejouer et changer de tour
                    UCCPartie.Instance.rejouerEtChangementDeSens(joueur);
                    UCCPartie.Instance.jeterCartePoubelle(joueur, idCarte);
                    break;
                default: return Json(new { success = false, message = "Probleme switch methode" }, JsonRequestBehavior.AllowGet);
         
            }
            return Json(new { success = true, message = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}