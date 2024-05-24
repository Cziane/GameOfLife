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
using DataLayerGameOfLife.Models;
using DataLayerGameOfLife.Repositories;

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

        private readonly IInitialStateRepository _initialStateRepository;

        private List<(int X, int Y)> initialAliveCells;

        private bool running;

        public MainWindow()
        {
            InitializeComponent();
            this._initialStateRepository = new InitialStateRepository();
            LoadData();
            initialAliveCells = new List<(int X, int Y)>();
            DrawGrid();
            this.running = false;
        }

        private void LoadData()
        {
            var initialStates = this._initialStateRepository.GetAll();
            InitialStateComboBox.ItemsSource = initialStates;
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
            DrawGameGrid();
        }

        private void DrawGrid()
        {
            GameCanvas.Children.Clear();

            for(int x = 0; x < Rows; x++)
            {
                for(int y = 0; y < Cols; y++)
                {
                    var cell = initialAliveCells.Contains((x, y));
                    var rectangle = new Rectangle
                    {
                        Width = Cellsize,
                        Height = Cellsize,
                        Fill = cell ? Brushes.Black : Brushes.White,
                        Stroke = Brushes.Gray
                    };

                    //Move the point I want to draw to y * cell size (rectangle point) x*cell size
                    Canvas.SetLeft(rectangle,y*Cellsize);
                    Canvas.SetTop(rectangle,x*Cellsize);

                    GameCanvas.Children.Add(rectangle);
                }
            }
        }

        private void DrawGameGrid()
        {
            GameCanvas.Children.Clear();

            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Cols; y++)
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
                    Canvas.SetLeft(rectangle, y * Cellsize);
                    Canvas.SetTop(rectangle, x * Cellsize);

                    GameCanvas.Children.Add(rectangle);
                }
            }
        }

        private void InitialStateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(InitialStateComboBox.SelectedItem is InitialState selectedState)
            {
                initialAliveCells = selectedState.ToAliveCells();
                DrawGrid();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (running == false)
            {
                var rule = new StandardRule();

                game = new GameOfLife.GameOfLife(Rows, Cols, rule, initialAliveCells);

                timer = new DispatcherTimer();

                timer.Tick += Timer_Tick;

                timer.Interval = TimeSpan.FromMilliseconds(500);

                timer.Start();

                Start.Content = "Stop";
            }
            else
            {
                timer.Stop();
                Start.Content = "Start";
            }

            running = !running;
            
            
        }

        private string GenerateStateString()
        {
            var sb = new StringBuilder();

            foreach(var (x,y) in initialAliveCells)
            {
                sb.Append($"{x},{y};");
            }
            return sb.ToString().TrimEnd(';');
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var name = InitialStateNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name for the initial state.");
                return;
            }

            var stateString = GenerateStateString();

            var initialState = new InitialState { Name = name, State= stateString};

            this._initialStateRepository.Add(initialState);
            LoadData();
            InitialStateNameTextBox.Clear();
            MessageBox.Show("Initial state created successfully.");

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(InitialStateComboBox.SelectedItem is InitialState selectedState)
            {
                this._initialStateRepository.Delete(selectedState.Id);
                LoadData();
                MessageBox.Show("Initial state delted sucessfully.");
            }
            else
            {
                MessageBox.Show("Please select an initial state to delete");
            }
        }

        private void GameCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point clickPosition = e.GetPosition(GameCanvas);

            int x = (int)(clickPosition.Y / Cellsize);
            int y = (int)(clickPosition.X / Cellsize);

            if (initialAliveCells.Contains((x, y)))
            {
                initialAliveCells.Remove((x, y));
            }
            else
            {
                initialAliveCells.Add((x,y));
            }

            DrawGrid();

        }
    }
}