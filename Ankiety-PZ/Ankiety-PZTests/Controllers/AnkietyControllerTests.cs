using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ankiety_PZ.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void WypelnijAnkieteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AktualizujWynikTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DodajAnkieteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ZapiszAnkieteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ZapiszPytanieTest()
        {
            Assert.Fail();
        }
    }
}