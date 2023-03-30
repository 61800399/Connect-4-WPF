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
        private int Y { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Make_Grid();
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
                    _label.Content = "O";
                    _label.Foreground = Brushes.White;
                    _label.Background = Brushes.Black;
                    _label.VerticalContentAlignment = VerticalAlignment.Center;
                    _label.HorizontalContentAlignment = HorizontalAlignment.Center;
                    _label.FontSize = 24;
                    _label.Margin = new Thickness(Lmargin, Tmargin, Rmargin, Bmargin);
                    _label.MouseLeftButtonDown += new MouseButtonEventHandler(OnClick);
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
            int[] Coordinates = new int[2];
            Label Lab = sender as Label;
            Coordinates = Get_Coordinates(Lab.Margin.Top, TestSquare.Height, Lab.Margin.Left, TestSquare.Width);
            Y = Board.Get_Y(Coordinates[0], _board.Grid, player);
            string txt = "";
            if (player == 1)
            {
                txt = "R";
            }
            else
            {
                txt = "Y";
            }
            foreach (Label L in Grid_board.Children)
            {
                if ((string)L.Tag == $"{Coordinates[0]}, {Y}")
                {
                    L.Content = txt;
                }
                
            }
            player = Board.Switch_Player(player);
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
        
    }
}
