using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrandCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrandCLI.Tests
{
    [TestClass()]
    public class FurdoTests
    {
        [TestMethod()]
        public void TelepulesTest()
        {
            Furdo teszt = new Furdo ("Gyulai Várfürdő;5700 Gyula, Várfürdő u. 1.; 6000; 36" );
            string vart = teszt.Telepules();
            Assert.AreEqual(vart, "Gyula");
        }

        [TestMethod()]
        public void NemjoTelepulesTest()
        {
            Furdo teszt = new Furdo("Gyulai Várfürdő;5700 Gyula, Várfürdő u. 1.; 6000; 36");
            string vart = teszt.Telepules();
            Assert.AreNotEqual(vart, "Gyula,");
        }

    }
}