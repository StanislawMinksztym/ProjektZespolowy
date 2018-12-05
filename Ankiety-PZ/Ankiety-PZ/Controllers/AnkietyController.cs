using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ankiety_PZ.Controllers
{
    public class AnkietyController : Controller
    {

        private Entities databaseManager = new Entities();

        // GET: Ankiety
        public ActionResult ListaAnkiet()
        {
            var ankietyList = new List<WyswietlAnkiety>();

            using (Entities ctx1 = new Entities())
            {
                var result = from t in ctx1.WyswietlAnkiety
                             select t;
                foreach (WyswietlAnkiety t in result)
                {
                    ankietyList.Add(t);
                }

            }

            ViewBag.ListaAnkiet = ankietyList;

            return View();
        }
        
        public ActionResult Wyniki(int id)
        {
            using (var ctx = new Entities())
            {
                var wyniki = ctx.WyswietlWynik(id).ToList();

                ViewBag.Wyniki = wyniki;
            }

            return View();
        }

        public ActionResult WypelnijAnkiete()
        {
            return View();
        }

    }
}