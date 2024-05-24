using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal interface IRule
    {
        Cell GetNextState(Cell cell, int aliveNeighbors);
    }
}
