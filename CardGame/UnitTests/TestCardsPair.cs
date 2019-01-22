using System;
using System.Collections.Generic;
using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TestCardsPair
    {
        public Game game = new Game();
        //KIER
        [TestMethod]
        public void TestPairOfKiers()
        {
            Assert.AreEqual("Sukces", game.GamesResult(new List<Cards>() { Cards.Kier, Cards.Kier }));
        }
        [TestMethod]
        public void TestPairOfKierAndKaro()
        {
            Assert.AreEqual("Sukces", game.GamesResult(new List<Cards>() { Cards.Kier, Cards.Karo }));
        }
        [TestMethod]
        public void TestPairOfKierAndTrefl()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Kier, Cards.Trefl }));
        }
        [TestMethod]
        public void TestPairOfKierAndPik()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Kier, Cards.Pik }));
        }

        //KARO
        [TestMethod]
        public void TestPairOfKaros()
        {
            Assert.AreEqual("Remis", game.GamesResult(new List<Cards>() { Cards.Karo, Cards.Karo }));
        }
        [TestMethod]
        public void TestPairOfKaroAndTrefl()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Karo, Cards.Trefl }));
        }
        [TestMethod]
        public void TestPairOfKaroAndPik()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Karo, Cards.Trefl }));
        }
        [TestMethod]
        public void TestPairOfKaroAndKier()
        {
            Assert.AreEqual("Sukces", game.GamesResult(new List<Cards>() { Cards.Karo, Cards.Kier }));
        }

        //Trefl
        [TestMethod]
        public void TestPairOfTrefls()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Trefl, Cards.Trefl }));
        }
        [TestMethod]
        public void TestPairOfTreflAndPik()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Trefl, Cards.Pik }));
        }
        [TestMethod]
        public void TestPairOfTreflAndKier()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Trefl, Cards.Kier }));
        }
        [TestMethod]
        public void TestPairOfTreflAndKaro()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Trefl, Cards.Karo }));
        }



        //PIK
        [TestMethod]
        public void TestPairOfPiks()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Pik, Cards.Pik }));
        }
        [TestMethod]
        public void TestPairOfPikAndTrefl()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Pik, Cards.Trefl }));
        }
        [TestMethod]
        public void TestPairOfPikAndKier()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Pik, Cards.Kier }));
        }
        [TestMethod]
        public void TestPairOfPikAndKaro()
        {
            Assert.AreEqual("Porażka", game.GamesResult(new List<Cards>() { Cards.Pik, Cards.Karo }));
        }
    }
}
