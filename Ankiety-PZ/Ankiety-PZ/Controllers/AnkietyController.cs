using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ankiety_PZ.Models;

namespace Ankiety_PZ.Controllers
{
    public class AnkietyController : Controller
    {

        private Entities databaseManager = new Entities();

        // GET: Ankiety
        public ActionResult Index()
        {

            //TEST:
            var a = "";
            using (Entities ctx = new Entities())
            {
                var result = from t in ctx.WyswietlAnkiety
                             select t;
                foreach (WyswietlAnkiety t in result)
                {
                    a = a + t.NazwaAnkiety + ",";
                }
            }

            ViewBag.TEST = a;

            return View();
        }

    }
}