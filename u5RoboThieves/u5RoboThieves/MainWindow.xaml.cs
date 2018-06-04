//Ethan Ross
//May23/2018
//somewhat complete solution of the robothieves problem
//Did this part in just under an hour
//Works without cameras or conveyors
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

namespace u5RoboThieves
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> differences = new List<int>();
        Point startPos;
        List<Point> spaces = new List<Point>();
        List<Point> reachables = new List<Point>();
        Char[,] inputs;
        int height;
        int width;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            txt.Text = "";
        }
        //Runs through the grid with the neighbourcheck method
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int counter = 0;
            int.TryParse(txt.Text[0].ToString(), out height);
            int.TryParse(txt.Text[2].ToString(), out width);
            inputs = new Char[height, width];
            //Gets grid of inputs
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width + 2; j++)
                {
                    if (j < width)
                    {
                        counter++;
                        inputs[i, j] = txt.Text[5 + j + ((width + 2) * i)];
                        //Console.WriteLine(inputs[i, j].ToString()+" "+counter.ToString());
                    }
                }
            }
            //Finds start position and runs neighbourcheck
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (inputs[i, j] == 'S')
                    {
                        startPos = new Point(i, j);
                        neighbourcheck(startPos);
                    }
                    else if (inputs[i, j] == '.')
                    {
                        spaces.Add(new Point(j, i));
                    }
                }
            }
            //Finds all point that exist in both arrays
            for(int i =0;i<spaces.Count;i++)
            {
                int difference;
                if (reachables.Contains(spaces[i]))
                {
                    Point check = spaces[i];
                    difference = Convert.ToInt32(Math.Abs(check.X - startPos.X) + Math.Abs(check.Y - startPos.Y));
                    
                }
                else
                {
                    difference = -1;

                }
                differences.Add(difference);
                
            }
            //Console.WriteLine(startPos);
            String output = "";
            for (int j = 0; j < differences.Count; j++)
            {
                //Console.WriteLine(spaces[j]);
                //Console.WriteLine(reachables[j]);
                Console.WriteLine(differences[j]);
                output += differences[j].ToString() + '\r'+'\n';
            }
            lbl.Content = output;
        }
        //Runs through the adjacent tiles of the current tile and checks what they are
        private void neighbourcheck(Point p)
        {
            int yp = Convert.ToInt32(p.Y);
            int xp = Convert.ToInt32(p.X);
            List<Point> points = new List<Point>();
            Point up = new Point(xp, yp-1);
            points.Add(up);
            Point left = new Point(xp-1, yp);
            points.Add(left);
            Point down = new Point(xp, yp+1);
            points.Add(down);
            Point right = new Point(xp+1,yp);
            points.Add(right);
            for(int i = 0;i<4;i++)
            {
                Point neighbour = points[i];
                int nx = Convert.ToInt32(neighbour.X);
                int ny = Convert.ToInt32(neighbour.Y);
                if (ny > 0 && nx > 0 && ny < height && nx < width)
                {
                    if (inputs[ny, nx] == '.')
                    {
                        if (!reachables.Contains(neighbour))
                        {
                            reachables.Add(neighbour);
                            //Console.WriteLine(neighbour.X+" "+neighbour.Y);
                            neighbourcheck(neighbour);
                        }
                    }
                }
            }
        }
    }
}
