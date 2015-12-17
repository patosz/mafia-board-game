using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;
using System.Web.Services;

namespace UI.Controllers
{
    public class PlateauController : Controller
    {
        UccPartieRef.GestionPartieClient partie = new UccPartieRef.GestionPartieClient();
        // GET: Plateau
        public ActionResult Index(string nomPartie = "Test")
        {
           /* if (nomPartie == null || nomPartie.Length == 0)
            {
                return RedirectToAction("Index", "Index");
            }*/
            //(new UccPartieRef.GestionPartieClient)
            ViewData["partie"] = nomPartie;
            return View();
        }

        [WebMethod]
        public ActionResult JouerCarte(string s = "")
        {
            if (s == "")
                return Json(new { success = false, message = "Problème param methode" }, JsonRequestBehavior.AllowGet);
            //TODO récuperer param requete
            //Request.Params.
            int idCarte = int.Parse(s);
            CarteDto carteDto = partie.getCarteDto(idCarte);
            int typeCarte = carteDto.CodeEffet;
            switch (typeCarte)
            {
                case 1:
                    //Supprimer 1 des
                    partie.supprimerUnDe
                    break;
                case 2:
                    //Donner des gauche ou droite

                    break;
                case 3:
                    //Supprimer 2 des

                    break;
                case 4:
                    //Donner 1 dé

                    break;
                case 5:
                    //Prendre 1 carte au joueur de mon choix

                    break;
                case 6:
                    //Joueur de mon choix n'a plus qu'une carte

                    break;
                case 7:
                    //Piocher 3 cartes

                    break;
                case 8:
                    //Tous les joueurs sauf moi n'ont plus que 2 cartes

                    break;
                case 9:
                    //Joueur de mon choix passe son tour

                    break;
                case 10:
                    //Rejouer et changer de tour

                    break;
                default: return Json(new { success = false, message = "Probleme switch methode" }, JsonRequestBehavior.AllowGet);
         
            }
            return Json(new { success = true, message = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}