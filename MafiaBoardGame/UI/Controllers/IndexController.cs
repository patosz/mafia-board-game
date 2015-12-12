﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Model;

namespace UI.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index(Joueur j)
        {
            return View(j);
        }
    }
}