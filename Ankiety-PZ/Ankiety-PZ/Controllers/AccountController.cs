using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;

namespace Ankiety_PZ.Controllers
{

    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Uzytkownicy objUser)
        {
            if (ModelState.IsValid)
            {
                using (Entities db = new Entities())
                {
                    var obj = db.Uzytkownicy.Where(a => a.Login.Equals(objUser.Login) && a.Haslo.Equals(objUser.Haslo)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.IdUzytkownika.ToString();
                        Session["UserName"] = obj.Login.ToString();
                        return RedirectToAction("../Ankiety/ListaAnkiet");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("ListaAnkiet", "Ankiety");
        }

    }
}