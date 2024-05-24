using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class DeadCell : Cell
    {
        public DeadCell(int x, int y) : base(x,y) { }

        public override bool IsAlive() => false;

        public override Cell NextState(int aliveNeighbors)
        {
            if(aliveNeighbors == 3)
            {
                return new AliveCell(X, Y);
            }

            return this;
        }
    }
}
