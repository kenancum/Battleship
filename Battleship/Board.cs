using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    public class Board
    {
        private string _boardString;
        private List<List<int>> emptyBombedTile;
        StringBuilder sb;
        private List<Battleship> battleships = new List<Battleship>();

        public Board()
        {

        }

        public Board(List<Battleship> battleships)
        {
            emptyBombedTile = new List<List<int>>();
            this.battleships = battleships;
            _boardString = createBoard();
            sb = new StringBuilder();
        }        

        public bool IsShootable(int line, int column)
        {
            int tilesToChange = this.tilesToChange(line, column);
            sb = new StringBuilder(_boardString);
            if (String.Equals(sb.ToString(tilesToChange,3),"   "))
            {
                return true;
            }
            return false;
        }

        public string Shoot(int line, int column)
        {
            List<int> shottedCoordinates = new List<int>() { line, column };

            foreach (var battleship in battleships)
            {
                foreach(var coordinate in battleship.GetCoordinates())
                {
                    if(coordinate.SequenceEqual(shottedCoordinates))
                    {
                        battleship.Hit();
                        _boardString = UpdateBoard(line, column, " X ");

                        if (!battleship.IsAlive)
                        {
                            return $"A {battleship.Name} sank!";
                        }
                        return "Hit!";
                    }
                }                
            }
            _boardString = UpdateBoard(line, column, " O ");
            return "Miss";
        }

        public string UpdateBoard(int line, int column, string hitType)
        {            
            int tilesToChange = this.tilesToChange(line, column);

            sb = new StringBuilder(_boardString);

            sb.Remove(tilesToChange, 3);
            sb.Insert(tilesToChange, hitType);

            _boardString = sb.ToString();
            return _boardString;
        }
                
        public string GetBoard() { return _boardString; }
        private string createBoard()
        {
            sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------");
            sb.AppendLine("|   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|");
            sb.AppendLine("---------------------------------------------");

            for (char c = 'A'; c <= 'J'; c++)
            {
                sb.Append($"| {c} |");
                for (int i = 0; i < 10; i++)
                {
                    sb.Append("   |");
                }
                sb.AppendLine();
                sb.AppendLine("---------------------------------------------");
            }
            return sb.ToString();
        }

        private int tilesToChange(int line, int column)
        {
            //A line contains 47 char. First 47 is for first ---- line,
            //94=47*2 for every line code should skip 2 lines
            //1 is for first '|' at the beginning of each line. for each column code should skip 4 chars. 
            return 47 + (94 * line) + 1 + (4 * column);
        }
    }
}
