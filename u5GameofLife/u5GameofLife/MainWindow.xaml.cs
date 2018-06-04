//Ethan Ross
//May 22,2018
//Emulates Conways Game of Life in a 20x20 grid
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
using System.Windows.Threading;

namespace u5GameofLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Rectangle[,] rectangles = new Rectangle[20, 20];
        Point loc;
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0;i<20;i++)
            {
                for(int j= 0;j<20;j++)
                {
                    Rectangle r = new Rectangle(); 
                    r.Width = 20;
                    r.Height = 20;
                    Canvas.SetLeft(r, j * 20);
                    Canvas.SetTop(r, i * 20);
                    r.Fill = Brushes.White;
                    r.Stroke = Brushes.Black;
                    r.StrokeThickness = 2;
                    rectangles[i, j] = r;
                    canvas.Children.Add(r);
                }
            }
            timer.Interval = new TimeSpan(0,0,0,1);
            timer.Tick += tick;
        }
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Start");
            timer.Start();
        }
        private void click(object sender, MouseEventArgs e)
        {
            loc = e.GetPosition(canvas);
            Console.WriteLine("Click" + loc.ToString());
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Rectangle r = rectangles[i, j];
                    if ((loc.X > Canvas.GetLeft(r) && loc.X < Canvas.GetLeft(r) + 20) && (loc.Y > Canvas.GetTop(r) && loc.Y < Canvas.GetTop(r) + 20))
                    {
                        //Console.WriteLine("True");
                        if(r.Fill == Brushes.White)
                        {
                            r.Fill = Brushes.Black;
                        }
                        else
                        {
                            r.Fill = Brushes.White;
                        }
                    }
                }
            }
        }
        private void tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    int maxx = 1;
                    int startx = -1;
                    int starty = -1;
                    int maxy = 1;
                    Rectangle r = rectangles[i, j];
                    int aliveneighbours = 0;
                    bool alive;
                    if (r.Fill == Brushes.Black)
                    {
                        alive =true;
                    }
                    else
                    {
                        alive = false;
                    }
                    
                    Rectangle[,] neighbours = new Rectangle[3, 3];
                    if (i == 19)
                    {
                        maxx = 0;
                    }
                    else if (i == 0)
                    {
                        startx = 0;
                    }
                    if (j == 19)
                    {
                        maxy = 0;
                    }
                    else if (j == 0)
                    {
                        starty = 0;
                    }
                    for (int x = startx; x <= maxx; x++)
                    {
                        for (int y = starty; y <= maxy; y++)
                        {
                            if (x == 0 && y == 0)
                            {

                            }
                            else
                            {
                                Rectangle neighbour = rectangles[i + x, j + y];
                                neighbours[x+1, y+1] = neighbour;
                                if (neighbours[x+1, y+1].Fill == Brushes.Black)
                                {
                                    aliveneighbours++;
                                }
                            }
                        }
                    }
                    if (r.Fill == Brushes.White)
                    {
                        if(aliveneighbours==3)
                        {
                            alive = true;
                        }
                        
                    }
                    else if (r.Fill == Brushes.Black)
                    {
                        if (aliveneighbours < 2 || aliveneighbours > 3)
                        {
                            alive = false;
                        }
                        else if (aliveneighbours == 2 || aliveneighbours == 3)
                        {
                            alive = true;
                        }
                    }

                    if (alive == true)
                    {
                        r.StrokeThickness = 3;
                    }
                    if(alive == false)
                    {
                        r.StrokeThickness = 2;
                    }
                }
            }
            for(int i = 0;i<20;i++)
            {
                for(int j = 0;j<20;j++)
                {
                    Rectangle r = rectangles[i, j];
                    if(r.StrokeThickness == 3)
                    {
                        r.Fill = Brushes.Black;
                    }
                    else
                    {
                        r.Fill = Brushes.White;
                    }
                    
                }
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0;i<20;i++)
            {
                for(int j = 0;j<20;j++)
                {
                    rectangles[i, j].Fill = Brushes.White;
                    rectangles[i, j].StrokeThickness = 2;
                }
            }
        }
    }
}
