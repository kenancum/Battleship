using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipGame
{
    public class Battleship
    {
        private string name;
        private int length;
        private bool isAlive;
        private List<Battleship> battleships;
        private List<List<int>> coordinates;
        public int hitCounter { get; set; }

        public Battleship(string name, int length, List<Battleship> battleships)
        {
            this.name = name;
            this.length = length;
            this.battleships = battleships;
            hitCounter = 0;
            isAlive = true;
            coordinates = new List<List<int>>();
            CreateCoordinates();
        }

        private void CreateCoordinates()
        {
            Random rnd = new Random();
            int cx, cy;
            bool recoordinate = true;
            while (recoordinate)
            {
                string direction = rnd.Next(2) == 0 ? "Horizontal" : "Vertical";

                if (String.Equals(direction, "Horizontal"))
                {
                    cx = rnd.Next(1, 12 - length);
                    cy = rnd.Next(1, 11);

                    for (int i = 0; i < length; i++)
                    {
                        this.coordinates.Add(new List<int>() { cx + i, cy });
                    }
                }
                else
                {
                    cx = rnd.Next(1, 11);
                    cy = rnd.Next(1, 12 - length);

                    for (int i = 0; i < length; i++)
                    {
                        this.coordinates.Add(new List<int>() { cx, cy + i });
                    }
                }
                recoordinate = areShipsCrossed();

                if (recoordinate)
                {
                    this.coordinates = new List<List<int>>();
                }
            }
        }

        public List<List<int>> GetCoordinates()
        {
            return coordinates;
        }

        private bool areShipsCrossed()
        {
            foreach (var battleship in battleships)
            {
                foreach (var thisShipCoordinates in this.GetCoordinates())
                {
                    foreach (var otherShipCoordinates in battleship.GetCoordinates())
                    {
                        if (thisShipCoordinates.SequenceEqual(otherShipCoordinates))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Hit()
        {
            this.hitCounter++;

            this.isAlive = this.hitCounter != this.length;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
    }
}