using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;

namespace UI.Controllers
{
    public class PlateauController : Controller
    {
        // GET: Plateau
        public ActionResult Index(string nomPartie)
        {
            if (nomPartie.Length == 0 || nomPartie == null)
            {
                return RedirectToAction("Index", "Index");
            }
            //(new UccPartieRef.GestionPartieClient)
            return View();
        }
    }
}