//Ethan Ross
// May 25,2018
// Math Tutor Program
using System;
using System.Collections.Generic;
using System.Linq;using System.Text;
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

namespace u5MathTutorEthanR
{
    public partial class MainWindow : Window
    {
        double answer;
        double v;
        public MainWindow()
        {
            InitializeComponent();
            Char[] stuff = { '*', '+', '-', '/' };
            Random r = new Random();
            int one = r.Next(1, 11);
            int two = r.Next(1, 11);
            Char Operator = stuff[r.Next(0, 4)];
            if (Operator == '*')
            {
                answer = one * two;
            }
            if (Operator == '+')
            {
                answer = one + two;
            }
            if (Operator == '-')
            {
                answer = one - two;
            }
            if (Operator == '/')
            {
                answer = one / two;
            }
            lbl.Content = one.ToString() + Operator.ToString() + two.ToString() + "=" + " ?";
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            double.TryParse(txt.Text, out v);
            if (answer == v)
            {
                MessageBox.Show("YOU DID IT");
            }
            else
            {
                MessageBox.Show("Not Really Correct At All");
            }
        }
    }
}