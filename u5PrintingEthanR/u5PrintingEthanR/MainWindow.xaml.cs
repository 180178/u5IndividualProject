//Ethan Ross
//June 4 2018
//solution for the printing problem
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

namespace u5PrintingEthanR
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

        private void btncalculate_Click(object sender, RoutedEventArgs e)
        {
            int copies;
            double priceper;
            double pricetotal;
            int.TryParse(txt.Text, out copies);
            if(copies<=99)
            {
                priceper = 0.30;
            }
            else if(copies<500)
            {
                priceper = 0.28;
            }
            else if(copies<749)
            {
                priceper = 0.27;
            }
            else if(copies<1001)
            {
                priceper = 0.26;
            }
            else
            {
                priceper = 0.25;
            }
            pricetotal = priceper * copies;
            lblitem.Content = "Price per copy is $" + priceper.ToString();
            lbltotal.Content = "Total cost is: $" + pricetotal.ToString();
        }
    }
}
