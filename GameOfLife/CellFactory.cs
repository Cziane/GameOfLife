using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class CellFactory : ICellFactory
    {
        public Cell CreateCell (int x, int y, bool isAlive)
        {
            if (isAlive)
            {
                return new AliveCell (x, y);
            }
            return new DeadCell (x, y);
        }
    }
}
