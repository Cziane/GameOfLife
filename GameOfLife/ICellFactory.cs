using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public interface ICellFactory
    {


        Cell CreateCell(int x, int y, bool isAlive);

    }
}
