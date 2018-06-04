//Ethan Ross
//June 1,2018
//Graphs a quadratic equation and outputs the roots, solution for the quadratic and quadratic extended questions
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

namespace u5QuadraticExtended
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Rectangle xaxis = new Rectangle();
            xaxis.Fill = Brushes.Black;
            xaxis.Height = 4;
            xaxis.Width = 400;
            Canvas.SetTop(xaxis, 196);
            canvas.Children.Add(xaxis);
            Rectangle yaxis = new Rectangle();
            yaxis.Fill = Brushes.Black;
            yaxis.Width = 4;
            yaxis.Height = 400;
            Canvas.SetLeft(yaxis, 196);
            canvas.Children.Add(yaxis);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            List<Ellipse> points = new List<Ellipse>();
            double a = 0;
            double b = 0;
            double c = 0;
            double.TryParse(txta.Text, out a);
            double.TryParse(txtb.Text, out b);
            double.TryParse(txtc.Text, out c);
            double root1 = (-b + Math.Sqrt((b * b) - 4 * a * c)) / (2 * a);
            double root2 = (-b - Math.Sqrt((b * b) - 4 * a * c)) / (2 * a);
            MessageBox.Show("The Roots Are " + root1.ToString() + ", " + root2.ToString());
            for(double x = -200; x<200;x+=0.01)
            {
                double y = -(a * x * x + b * x + c);
                Ellipse point = new Ellipse();
                point.Height = 2;
                point.Width = 2;
                point.Fill = Brushes.Blue;
                points.Add(point);
                Canvas.SetTop(point, y + 199);
                Canvas.SetLeft(point, x + 199);
                canvas.Children.Add(point);
            }
            Ellipse root1e = new Ellipse();
            root1e.Width = 4;
            root1e.Height = 4;
            root1e.Fill = Brushes.Red;
            Canvas.SetLeft(root1e, root1+198);
            Canvas.SetTop(root1e,196);
            canvas.Children.Add(root1e);

            Ellipse root2e = new Ellipse();
            root2e.Width = 4;
            root2e.Height = 4;
            root2e.Fill = Brushes.Red;
            Canvas.SetLeft(root2e, root2 + 198);
            Canvas.SetTop(root2e,196);
            canvas.Children.Add(root2e);
        }
    }
}
