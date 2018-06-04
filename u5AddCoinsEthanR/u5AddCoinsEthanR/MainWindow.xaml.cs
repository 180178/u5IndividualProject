//Ethan Ross
//June 4 2018
//Adds coins
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

namespace u5AddCoinsEthanR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int twoonies;
            int loonies;
            int quarters;
            int dimes;
            int nickels;
            int.TryParse(txttwo.Text, out twoonies);
            int.TryParse(txtloo.Text, out loonies);
            int.TryParse(txtquart.Text, out quarters);
            int.TryParse(txtdime.Text, out dimes);
            int.TryParse(txtnick.Text, out nickels);
            double total = (twoonies * 2) + loonies + (quarters * 0.25) + (dimes * 0.10) + (nickels * 0.05);
            lblout.Content = "Total:   $" + total;

        }
    }
}
