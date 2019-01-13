using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ankiety_PZ.Controllers;
using System;
using System.Collections.Generic;
using Moq;
using System.Web;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Ankiety_PZ.Controllers.Tests
{
    [TestClass()]
    public class AnkietyControllerTests
    {
        [TestMethod()]
        public void ListaAnkietTest()
        {
            var testlist = new List<WyswietlAnkiety>();

            var controller = new AnkietyController();
            var result = controller.ListaAnkiet() as ViewResult;
            Assert.IsNotNull(result.ViewBag.ListaAnkiet);
        }

        [TestMethod()]
        public void WynikiTest()
        {
            var controller = new AnkietyController();
            var context = MockRepository.GenerateStub<ControllerContext>();
            context.Expect(x => x.HttpContext.Session["MyKey"]).Return("MyValue");
            controller.ControllerContext = context;
            controller.Wyniki(1);

            Assert.IsNotNull(controller);
        }

        [TestMethod()]
        public void ZapiszAnkieteTest()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var controller = new AnkietyController();
            var session = new Mock<HttpSessionStateBase>();

            var sessionDict = new Dictionary<string, string>
            {
                {"UserId", "1" },
            };

            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                HttpContext = context.Object,
            };
            var ankieta = new NameValueCollection();
            ankieta.Add("NazwaAnkiety", "Ankieta testowa");
            
            controller.Session.Add("UserId", "1");
            context.Setup(c => c.Request.Form).Returns(ankieta);
            var result = controller.ZapiszAnkiete();

            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public void ZapiszPytanieTest()
        {
            var request = new Mock<HttpRequestBase>();
            var context = new Mock<HttpContextBase>();
            var controller = new AnkietyController();

            var pytanie = new NameValueCollection();
            pytanie.Add("odp_1", "odpowiedź 1");
            pytanie.Add("odp_2", "odpowiedź 2");
            pytanie.Add("odp_3", "odpowiedź 3");
            pytanie.Add("odp_4", "odpowiedź 4");
            pytanie.Add("odp_5", "odpowiedź 5");
            pytanie.Add("odp_6", "odpowiedź 6");
            pytanie.Add("wielo", "true");
            pytanie.Add("id_ankiety", "2");
            pytanie.Add("pyt1", "pytanie_testowe");

            context.Setup(m => m.Request.Form).Returns(pytanie);
            controller.ControllerContext = new ControllerContext
            {
                Controller = controller,
                HttpContext = context.Object
            };
            var result = controller.ZapiszPytanie();

            Assert.AreNotEqual(0, result);
        }
    }
}