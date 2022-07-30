using BattleshipGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGameTests
{
    [TestClass]
    public class BattleshipTests
    {
        private List<Battleship> _battleships = new List<Battleship>();

        [TestInitialize]
        public void Initialize()
        {
            Battleship battleship = new("battleship", 5, _battleships);
            _battleships.Add(battleship);

            Battleship destroyer1 = new("destroyer", 4, _battleships);
            _battleships.Add(destroyer1);

            Battleship destroyer2 = new("destroyer", 4, _battleships);
            _battleships.Add(destroyer2);
        }

        [TestMethod]
        public void GetCoordinatesTest()
        {
            var battleship = _battleships[_battleships.Count - 1];

            Assert.AreEqual(battleship.Length, battleship.GetCoordinates().Count);
        }

        [TestMethod]
        public void HitTest()
        {
            var battleship = _battleships[0];

            for (int i = 0; i < battleship.Length; i++)
            {
                battleship.Hit();
            }
            Assert.AreEqual(battleship.Length, battleship.hitCounter);
            Assert.IsFalse(battleship.IsAlive);
        }
    }
}
