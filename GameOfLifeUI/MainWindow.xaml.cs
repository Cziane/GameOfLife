using System.Text;
using System.Windows;
using GameOfLife;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLifeUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Cellsize = 20;
        private const int Rows = 20;
        private const int Cols = 40;

        private GameOfLife.GameOfLife game;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            var initialAliveCElls = new List<(int X, int Y)>
            {
                (1,1),(1,2),(1,3)
            };

            var rule = new StandardRule();
            game = new GameOfLife.GameOfLife(Rows, Cols, rule, initialAliveCElls);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object send,EventArgs e)
        {
            game.Update();
            DrawGrid();
        }

        private void DrawGrid()
        {
            GameCanvas.Children.Clear();

            for(int x = 0; x < Rows; x++)
            {
                for(int y = 0; y < Cols; y++)
                {
                    var cell = game.GetCell(x, y);
                    var rectangle = new Rectangle
                    {
                        Width = Cellsize,
                        Height = Cellsize,
                        Fill = cell.IsAlive() ? Brushes.Black : Brushes.White,
                        Stroke = Brushes.Gray
                    };

                    //Move the point I want to draw to y * cell size (rectangle point) x*cell size
                    Canvas.SetLeft(rectangle,y*Cellsize);
                    Canvas.SetTop(rectangle,x*Cellsize);

                    GameCanvas.Children.Add(rectangle);
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
                Start.Content = "Stop";
            }
            else
            {
                timer.Stop();
                Start.Content = "Start";
            }
            
        }
    }
}