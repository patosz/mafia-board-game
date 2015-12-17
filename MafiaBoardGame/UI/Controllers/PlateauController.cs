﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;
using System.Web.Services;
using Newtonsoft.Json;

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

        public ActionResult Index2(string nomPartie = "Test")
        {
            ViewData["partie"] = nomPartie;
            
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

            CarteDto carteDto = partie.getCarteDto(idCarte);
            int typeCarte = carteDto.CodeEffet;
            switch (typeCarte)
            {
                case 1:
                    //Supprimer 1 des
                    partie.supprimerUnDe(joueur);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 2:
                    //Donner des gauche ou droite
                    if (sens == "G")
                        partie.donnerDeAGaucheOuDroite(false);
                    else
                        partie.donnerDeAGaucheOuDroite(true);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 3:
                    //Supprimer 2 des
                    partie.supprimerDeuxDes(joueur);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 4:
                    //Donner 1 dé
                    partie.donnerUnDeAUnJoueur(joueur, deChoisi);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 5:
                    //Prendre 1 carte au joueur de mon choix
                    partie.prendreUneCarteDUnJoueur(joueur, cible);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 6:
                    //Joueur de mon choix n'a plus qu'une carte
                    partie.ciblerJoueurQUUneCarte(cible);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 7:
                    //Piocher 3 cartes
                    partie.piocheTroisCartes(joueur);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 8:
                    //Tous les joueurs sauf moi n'ont plus que 2 cartes
                    partie.plusQueDeuxCartesPourLesAutres(joueur);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 9:
                    //Joueur de mon choix passe son tour

                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                case 10:
                    //Rejouer et changer de tour
                    partie.rejouerEtChangementDeSens(joueur);
                    partie.jeterCartePoubelle(joueur, idCarte);
                    break;
                default: return Json(new { success = false, message = "Probleme switch methode" }, JsonRequestBehavior.AllowGet);
         
            }
            return Json(new { success = true, message = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}