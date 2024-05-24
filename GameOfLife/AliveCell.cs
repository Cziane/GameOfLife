using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class AliveCell : Cell
    {


        public AliveCell(int x, int y):base(x, y) { }

        public override bool IsAlive() => true;

        public override Cell NextState(int aliveNeighbors)
        {
            if(aliveNeighbors<2 || aliveNeighbors > 3)
            {
                return new DeadCell(X, Y);
            }

            return this;
        }

    }
}
