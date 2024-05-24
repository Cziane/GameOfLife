using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    internal class Grid
    {
        private readonly int rows;
        private readonly int columns;

        private readonly Cell[,] cells;
        
        private readonly ICellFactory cellFactory;

        private readonly IRule rule;


        public Grid(int row, int cols, ICellFactory factory, IRule rule, List<(int x, int y)> initialAliveCells)
        {
            this.rows = row;
            this.columns = cols;
            this.cells = new Cell[rows, cols];
            this.cellFactory = factory;
            this.rule = rule;
            InitializeGrid(initialAliveCells);
        }

        public void InitializeGrid(List<(int x, int y)> initialAliveCells)
        {
            for(int x= 0; x< this.rows; ++x)
            {
                for(int y = 0; y< this.columns; ++y)
                {
                    this.cells[x, y] = this.cellFactory.CreateCell(x, y, false);
                }
            }

            foreach(var (x,y) in initialAliveCells)
            {
                if(x>=0 && x< rows && y>=0 && y< columns)
                {
                    cells[x,y]= cellFactory.CreateCell(x, y, true);
                }
            }
        }

        public void UpdateGrid()
        {
            Cell[,] newCells = new Cell[rows, columns];

            for(int x= 0;x< rows; ++x)
            {
                for (int y= 0; y< columns; ++y)
                {
                    int aliveNeighbors = GetAliveNeighborsCount(x, y);
                    newCells[x, y] = rule.GetNextState(cells[x, y], aliveNeighbors);
                }
            }

            Array.Copy(newCells,cells,newCells.Length);
        }

        private int GetAliveNeighborsCount(int x, int y)
        {
            int count = 0;

            for(int i=-1; i <= 1; ++i)
            {
                for(int j=-1;j<=1; ++j)
                {
                    if (i == 0 && j == 0) continue;

                    int newX = x + i;
                    int newY = y + j;

                    //If I am in the array and my cell is alive I increment my counter.
                    if (newX >= 0 && newY >= 0 && newX<rows && newY < columns && cells[newX,newY].IsAlive())
                    {
                        count++;
                    }

                }


            }

            return count;

        }

        public Cell GetCell(int x, int y)
        {
            return this.cells[x, y];
        }
    }
}
