using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect_4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board = new Board();
        public int player { get; set; } = 1;
        private int _Y { get; set; }
        private bool Win;
        public MainWindow()
        {
            InitializeComponent();
            Make_Grid();
            WinnerLab.Content = "it is player 1's turn";
        }
        private void Make_Grid()
        {
            int count = 0;
            int Y = 0;
            double Lmargin;
            double Tmargin;
            double Rmargin;
            double Bmargin;
            foreach (var squares in _board.Grid)
            {
                foreach (var square in squares)
                {
                    Label _label = new Label();
                    Grid_board.Children.Add(_label);
                    Lmargin = TestSquare.Margin.Left + (TestSquare.Width * count);
                    Tmargin = TestSquare.Margin.Top + (TestSquare.Height * Y);
                    Rmargin = TestSquare.Margin.Right - (TestSquare.Width * count);
                    Bmargin = TestSquare.Margin.Bottom - (TestSquare.Height * Y);
                    _label.Width = TestSquare.Width;
                    _label.Height = TestSquare.Height;
                    _label.Content = "🔴";
                    _label.Foreground = Brushes.White;
                    _label.Background = Brushes.LightGray;
                    _label.VerticalContentAlignment = VerticalAlignment.Center;
                    _label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    _label.FontSize = 24;
                    _label.Margin = new Thickness(Lmargin, Tmargin, Rmargin, Bmargin);
                    _label.MouseLeftButtonDown += new MouseButtonEventHandler(OnClick);
                    _label.MouseMove += new MouseEventHandler(Highlight);
                    int[] Location = new int[2];
                    Location = Get_Coordinates(_label.Margin.Top, TestSquare.Height, _label.Margin.Left, TestSquare.Width);
                    _label.Tag = $"{Location[0]}, {Location[1]}";
                    if (count == 0)
                    {
                        count++;
                        continue;
                    }
                    else if (count % 6 == 0)
                    {
                        count = 0;
                        Y++;
                        continue;
                    }
                    count++;
                }
            }
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var color = Brushes.Black;
            if (Win == true)
            {
                return;
            }
            int[] Coordinates = new int[2];
            Label Lab = sender as Label;
            Coordinates = Get_Coordinates(Lab.Margin.Top, TestSquare.Height, Lab.Margin.Left, TestSquare.Width);
            _Y = Board.Get_Y(Coordinates[0], _board.Grid, player, true);
            if (_Y == 48)
            {
                return;
            }
            if (player == 1)
            {
                color = Brushes.Red;
            }
            else
            {
                color = Brushes.Yellow;
            }
            int EmptyCount = 0;
            foreach (Label L in Grid_board.Children)
            {
                if ((string)L.Tag == $"{Coordinates[0]}, {_Y}")
                {
                    L.Foreground = color;
                }
                else if (L.Foreground == Brushes.White || L.Foreground == new SolidColorBrush(Color.FromArgb(50, 255, 0, 0)) || L.Foreground == new SolidColorBrush(Color.FromArgb(50, 255, 255, 0)))
                {
                    EmptyCount++;
                }
            }
            if (EmptyCount < 43)
            {
                RestartBut.Visibility = Visibility.Visible;
            }
            else
            {
                RestartBut.Visibility = Visibility.Collapsed;
            }
            if (Player.Check_Win(player, _board.Grid))
            {
                Win = true;
                WinnerLab.Content = $"player {player} won";
                Again.Content = "Play again?";
                Again.Visibility = Visibility.Visible;
                RestartBut.Visibility = Visibility.Collapsed;
                return;
            }
            player = Board.Switch_Player(player);
            WinnerLab.Content = $"it is player {player}'s turn";
        }
        private static int[] Get_Coordinates(double TopDistance, double Hdiv, double LeftDistance, double Wdiv)
        {
            double Y = TopDistance / Hdiv;
            double X = LeftDistance / Wdiv;
            int[] coords = new int[2]
            {
                (int)X, (int) Y
            };
            return coords;
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            _board = new Board();
            player = 1;
            Grid_board.Children.Clear();
            Make_Grid();
            Again.Visibility = Visibility.Collapsed;
            WinnerLab.Content = "it is player 1's turn";
            Win = false;
        }
        private void Highlight(object sender, RoutedEventArgs e)
        {
            if (Win)
            {
                return;
            }
            Label Lab = sender as Label;
            string[] Pos = Lab.Tag.ToString().Split(',');
            //Pos[0].Replace(" ", null);
            int.TryParse(Pos[0], out int X);
            int.TryParse(Pos[1], out int Y);
            //MessageBox.Show($"{Pos[0]}, {Pos[1]}");
            int[] Coordinates = new int[2];
            Coordinates = Get_Coordinates(Lab.Margin.Top, TestSquare.Height, Lab.Margin.Left, TestSquare.Width);
            _Y = Board.Get_Y(Coordinates[0], _board.Grid, player, false);
            SolidColorBrush NewColor;
            if (_Y == 48)
            {
                return;
            }
            if (player == 1)
            {
                NewColor = new SolidColorBrush(Color.FromArgb(50, 255, 0, 0));
            }
            else
            {
                NewColor = new SolidColorBrush(Color.FromArgb(50, 255, 255, 0));
            }
            
            foreach (Label L in Grid_board.Children)
            {
                if (L.Foreground == Brushes.Red || L.Foreground == Brushes.Yellow)
                {
                    continue;
                }
                if ((string)L.Tag == $"{Coordinates[0]}, {_Y}" && L.Foreground == Brushes.White)
                {
                    L.Foreground = NewColor;
                }
                else if ((string)L.Tag != $"{Coordinates[0]}, {_Y}")
                {
                    L.Foreground = Brushes.White;
                }
                
                
            }
        }
    }
}
