using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerGameOfLife.Models
{
    public class InitialState
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string State { get; set; }


        public override string ToString()
        {
            return $"{Name}";
        }

        public List<(int x, int y)> ToAliveCells()
        {
            var aliveCells = new List<(int x, int y)>();

            if(string.IsNullOrEmpty(State)) return aliveCells;


            //eg of State 1,2;1,3;5,4 
            var cellCoordinates = State.Split(';');

            foreach(var coordinate in cellCoordinates)
            {
                var parts = coordinate.Split(',');

                if(int.TryParse(parts[0], out int x) &&
                    int.TryParse(parts[1], out int y))
                {
                    aliveCells.Add((x, y));
                }
            }

            return aliveCells;
        }
    }
}
