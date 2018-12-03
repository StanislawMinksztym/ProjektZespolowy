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

            //TEST1:
            var a = "";
            using (Entities ctx1 = new Entities())
            {
                var result = from t in ctx1.WyswietlAnkiety
                             select t;
                foreach (WyswietlAnkiety t in result)
                {
                    a = a + t.NazwaAnkiety + ",";
                }
            }

            //TEST2:
            var b = "";
            Entities ctx2 = new Entities();

            var pytaniaList = ctx2.WypelnijAnkiete(1).ToList();


            foreach (WypelnijAnkiete_Result p in pytaniaList)
            {

                b = b + p.NazwaAnkiety + "," + p.Pytanie +"," + p.Odp_1 + "," + p.Odp_2 + ","+p.Odp_3 + "," +p.Odp_4+ "," +p.Odp_5+ ","+p.Odp_6 + "," + p.Odp_7 + "," + p.Odp_8 + "," + p.Odp_9 + "," + p.Odp_10;
            }

            ViewBag.TEST1 = a;

            ViewBag.TEST2 = b;

            return View();
        }

    }
}