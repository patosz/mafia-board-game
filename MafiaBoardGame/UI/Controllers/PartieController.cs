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
            if (Session["user"] == null)
                throw new Exception("Session is null :p");

            return View((JoueurDto) Session["user"]);
        }

        public bool Rejoindre(string pseudo)
        {

            return false;
        }

        [HttpPost]
        public bool Creer(string nom)
        {
            return false;
        }
    }
}