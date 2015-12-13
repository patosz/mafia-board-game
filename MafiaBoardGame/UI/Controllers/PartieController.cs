using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace UI.Controllers
{
    public class PartieController : Controller
    {
        // GET: Partie
        public ActionResult Index(String pseudo)
        {
            if (TempData["myUser"] == null)
                throw new Exception("ViewData null :p");

            return View((JoueurDto) TempData["myUser"]);
        }
    }
}