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

        public ActionResult WypelnijAnkiete(int id)
        {
            using (var ctx = new Entities())
            {
                var pytania = ctx.WyswietlPytania(id).ToList();

                ViewBag.Pytania = pytania;
            }

            return View();
        }

        [HttpPost]
        public ActionResult AktualizujWynik(FormCollection collection)
        {
            var wyniki = new Dictionary<string, object>();
            Request.Form.CopyTo(wyniki);

            //AktualizujWynik(idankiety, idpytania, nrodpowiedzi);

            var idAnkiety = Convert.ToInt32(wyniki["IdAnkiety"]);

            using (var ctx = new Entities())
            {
                foreach (var w in wyniki) { 
                    if(w.Key != "IdAnkiety") {
                        var a = Convert.ToInt32(w.Key);
                        var odps = w.Value.ToString().Split(',');
                        foreach(var o in odps)
                        {
                            ctx.AktualizujWynik(idAnkiety, Convert.ToInt32(w.Key), Convert.ToInt32(o));
                        }
                        
                    }

                }
            }

            var value1 = Request.Form.ToString();

            return RedirectToAction("ListaAnkiet");
        }
    }
}