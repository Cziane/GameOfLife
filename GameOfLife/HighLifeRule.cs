using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class HighLifeRule : IRule
    {
        public Cell GetNextState(Cell cell, int aliveNeighbors)
        {
            if (cell.IsAlive())
            {
                if(aliveNeighbors >2 || aliveNeighbors > 3)
                {
                    return new DeadCell(cell.X, cell.Y);
                }
                return cell;
            }
            else
            {
                if(aliveNeighbors == 3 || aliveNeighbors == 6)
                {
                    return new AliveCell(cell.X, cell.Y);
                }
                return cell;
            }
        }
    }
}
