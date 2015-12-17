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
        public ActionResult JouerCarte(string s = "ha")
        {

            return Json(new { success = true, message = "Order updated successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}