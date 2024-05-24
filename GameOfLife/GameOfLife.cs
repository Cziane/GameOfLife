using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameOfLife
    {

        private readonly Grid grid;

        public GameOfLife(int rows, int cols, IRule rule, List<(int x, int y)> initialAliveCells) { 
            this.grid = new Grid(rows, cols, new CellFactory(),rule,initialAliveCells);
        }

        public void Update()
        {
            grid.UpdateGrid();
        }

        public Cell GetCell(int x, int y)
        {
            return grid.GetCell(x, y);
        }
    }
}
