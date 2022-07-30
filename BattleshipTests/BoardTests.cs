using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleshipGameTests
{
    [TestClass]
    public class BoardTests
    {
        private List<Battleship> _battleships = new List<Battleship>();
        private Board _board = new Board();
        StringBuilder hitString;
        StringBuilder boardString;

        [TestInitialize]
        public void Initialize()
        {
            Battleship battleship = new("battleship", 5, _battleships);
            _battleships.Add(battleship);

            Battleship destroyer1 = new("destroyer", 4, _battleships);
            _battleships.Add(destroyer1);

            Battleship destroyer2 = new("destroyer", 4, _battleships);
            _battleships.Add(destroyer2);

            _board = new Board(_battleships);

            hitString = new StringBuilder();
            boardString = new StringBuilder();

            #region Strings
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| A | X |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| B |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| C |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| D |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| E |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| F |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| G |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| H |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| I |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");
            hitString.AppendLine("| J |   |   |   |   |   |   |   |   |   |   |");
            hitString.AppendLine("---------------------------------------------");


            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| A |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| B |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| C |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| D |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| E |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| F |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| G |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| H |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| I |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            boardString.AppendLine("| J |   |   |   |   |   |   |   |   |   |   |");
            boardString.AppendLine("---------------------------------------------");
            #endregion
        }

        [TestMethod]
        public void UpdateBoardTest()
        {
            Assert.AreEqual(hitString.ToString(), _board.UpdateBoard(1,1," X "));            
        }

        [TestMethod]
        public void GetBoardTest()
        {
            Assert.AreEqual(boardString.ToString(), _board.GetBoard());
        }

        [TestMethod]
        public void IsShootableTest()
        {
            Assert.IsTrue(_board.IsShootable(1,1));

            _board.UpdateBoard(1,1," O ");

            Assert.IsFalse(_board.IsShootable(1, 1));
        }

        [TestMethod]
        public void ShootTest()
        {
            Assert.AreEqual("Miss", _board.Shoot(1, 1));
        }
    }
}
