using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Dto;

namespace UI.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index(JoueurDto j)
        {
            if (Session["user"] != null)
                return RedirectToAction("Index", new { controller = "Partie" });

            return View(j);
        }
    }
}