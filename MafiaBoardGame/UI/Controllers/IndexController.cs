using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace UI.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index(JoueurDto j)
        {
            return View(j);
        }
    }
}