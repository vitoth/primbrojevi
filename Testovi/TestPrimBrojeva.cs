using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood;

namespace Testovi
{
    [TestClass]
    public class TestPrimBrojeva
    {
        [TestMethod]
        public void GenerirajPrimBrojeveVraćaPrazanNizZa0()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(0).Length);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveVraćaPrazanNizZa1()
        {
            Assert.AreEqual(0, Program.GenerirajPrimBrojeve(1).Length);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveVraćaNizKojiSadržiSamo2ZaArgument2()
        {
            Assert.AreEqual(1, Program.GenerirajPrimBrojeve(2).Length);
            Assert.AreEqual(2, Program.GenerirajPrimBrojeve(2)[0]);
        }

        [TestMethod]
        public void GenerirajPrimBrojeveVraćaNizKojiSadrži25PrimBrojevaZaArgument100()
        {
            var primBrojevi = Program.GenerirajPrimBrojeve(100);
            Assert.AreEqual(25, primBrojevi.Length);
            Assert.AreEqual(2, primBrojevi[0]);
            Assert.AreEqual(97, primBrojevi[primBrojevi.Length-1]);
        }
    }
}
