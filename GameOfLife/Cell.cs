namespace GameOfLife
{
    public abstract class Cell
    {

        public int X { get; set; }

        public int Y { get; set; }

        protected Cell(int x, int y) {
            this.X= x;
            this.Y= y;
        }

        public abstract bool IsAlive();

        public abstract Cell NextState(int aliveNeighbors);


    }
}
