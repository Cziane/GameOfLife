using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class StandardRule : IRule
    {
        public Cell GetNextState(Cell cell, int aliveNeighbors)
        {
            return cell.NextState(aliveNeighbors);
        }
    }
}
