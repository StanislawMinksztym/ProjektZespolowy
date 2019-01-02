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

        public ActionResult ListaAnkiet()
        {
            var ankietyList = new List<WyswietlAnkiety>();
            var doWywalenia = new List<Int32>();
            using (Entities ctx1 = new Entities())
            {
                var result = from t in ctx1.WyswietlAnkiety select t;

                ctx1.SaveChanges();

                foreach (WyswietlAnkiety t in result)
                {
                    var pytania = ctx1.WyswietlPytania(t.IdAnkiety).ToList().Count();

                    if (pytania == 0)
                    {
                        doWywalenia.Add(t.IdAnkiety);
                    }
                    else
                    {
                        ankietyList.Add(t);
                    }
                }
            }

            using (Entities ctx2 = new Entities())
            {
                foreach (int id in doWywalenia)
                {
                    ctx2.UsunAnkiete(id);
                }
            }

            ViewBag.ListaAnkiet = ankietyList;

            return View();
        }

        public ActionResult Wyniki(int id)
        {
            if (Session.Keys.Count != 0)
            {
                using (var ctx = new Entities())
                {
                    var wyniki = ctx.WyswietlWynik(id).ToList();
                    ViewBag.Wyniki = wyniki;
                }
                return View();
            }
            else
            {
                return RedirectToAction("ListaAnkiet");
            }
        }

        public ActionResult WypelnijAnkiete(int id)
        {
            using (var ctx = new Entities())
            {
                var pytania = ctx.WyswietlPytania(id).ToList();
                ViewBag.Pytania = pytania;
                ViewBag.idAnkiety = id;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AktualizujWynik(FormCollection collection)
        {
            var wyniki = new Dictionary<string, object>();
            Request.Form.CopyTo(wyniki);
            var idAnkiety = Convert.ToInt32(wyniki["IdAnkiety"]);
            using (var ctx = new Entities())
            {
                foreach (var w in wyniki)
                {
                    if (w.Key != "IdAnkiety")
                    {
                        var odps = w.Value.ToString().Split(',');
                        foreach (var o in odps)
                        {
                            ctx.AktualizujWynik(idAnkiety, Convert.ToInt32(w.Key), Convert.ToInt32(o));
                        }
                    }
                }
            }
            return RedirectToAction("ThankYouPage");
        }
        public ActionResult ThankYouPage()
        {
            return View();
        }

        public ActionResult DodajAnkiete()
        {
            if (Session.Keys.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ListaAnkiet");
            }
        }


        [HttpGet]
        public Int32 ZapiszAnkiete()
        {
            using (var ctx = new Entities())
            {
                var idAnkiety = Convert.ToInt32(ctx.DodajAnkiete(Request["NazwaAnkiety"], Convert.ToInt32(Session["UserId"])).ToList()[0]);
                return idAnkiety;
            }
        }

        [HttpPost]
        public Int32 ZapiszPytanie()
        {
            var pytanie = new Dictionary<string, object>();
            Request.Form.CopyTo(pytanie);
            String odp1, odp2, odp3, odp4, odp5, odp6, odp7, odp8, odp9, odp10;
            bool wielo = false;
            if (pytanie.ContainsKey("wielo")) { wielo = true; };
            if (pytanie.ContainsKey("odp_1")) { odp1 = pytanie["odp_1"].ToString(); } else { odp1 = null; };
            if (pytanie.ContainsKey("odp_2")) { odp2 = pytanie["odp_2"].ToString(); } else { odp2 = null; };
            if (pytanie.ContainsKey("odp_3")) { odp3 = pytanie["odp_3"].ToString(); } else { odp3 = null; };
            if (pytanie.ContainsKey("odp_4")) { odp4 = pytanie["odp_4"].ToString(); } else { odp4 = null; };
            if (pytanie.ContainsKey("odp_5")) { odp5 = pytanie["odp_5"].ToString(); } else { odp5 = null; };
            if (pytanie.ContainsKey("odp_6")) { odp6 = pytanie["odp_6"].ToString(); } else { odp6 = null; };
            if (pytanie.ContainsKey("odp_7")) { odp7 = pytanie["odp_7"].ToString(); } else { odp7 = null; };
            if (pytanie.ContainsKey("odp_8")) { odp8 = pytanie["odp_8"].ToString(); } else { odp8 = null; };
            if (pytanie.ContainsKey("odp_9")) { odp9 = pytanie["odp_9"].ToString(); } else { odp9 = null; };
            if (pytanie.ContainsKey("odp_10")) { odp10 = pytanie["odp_10"].ToString(); } else { odp10 = null; };
            using (var ctx = new Entities())
            {
                ctx.DodajPytanie(Convert.ToInt32(pytanie["id_ankiety"]), wielo, pytanie["pyt1"].ToString(), odp1, odp2, odp3, odp4, odp5, odp6, odp7, odp8, odp9, odp10);
            }
            return Convert.ToInt32(pytanie["id_ankiety"]);
        }
    }
}