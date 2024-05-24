using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class CustomRule : IRule
    {

        private readonly string  birthCondition;

        private readonly string survivalCondition;

        public CustomRule(string ruleLogic)
        {
            //Eg: of ruleLogic B3/S6
            this.birthCondition = ruleLogic.Split('/')[0].Substring(1); // 3
            this.survivalCondition = ruleLogic.Split('/')[1].Substring(1);//6
        }

        public Cell GetNextState(Cell cell, int aliveNeighbors)
        {
            if (cell.IsAlive())
            {
                if (survivalCondition.Contains(aliveNeighbors.ToString()))
                {
                    return cell;
                }
                else
                {
                    return new DeadCell(cell.X, cell.Y);
                }
            }
            else
            {
                if (birthCondition.Contains(aliveNeighbors.ToString()))
                {
                    return new AliveCell(cell.X, cell.Y);
                }
                else
                {
                    return cell;
                }
            }
        }
    }
}
