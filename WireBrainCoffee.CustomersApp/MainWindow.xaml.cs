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

namespace WireBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly GridLength HiddenColumnWidth = GridLength.Auto;
        public static readonly double HiddenColumnMinWidth = 0.0;

        public static readonly int MainGridFirstColumn = 0;
        public static readonly int MainGridLastColumn = 2;

        private readonly ColumnDefinitionCollection customerViewGrid_CDC;

        public MainWindow()
        {
            InitializeComponent();

            customerViewGrid_CDC = customerViewGrid.ColumnDefinitions;
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            if (customerViewGrid_CDC[MainGridFirstColumn].MinWidth == HiddenColumnMinWidth)
            {
                /* Sets the customer list to the left side. */

                customerViewGrid_CDC[MainGridFirstColumn].Width = customerViewGrid_CDC[MainGridLastColumn].Width;
                customerViewGrid_CDC[MainGridFirstColumn].MinWidth = customerViewGrid_CDC[MainGridLastColumn].MinWidth;

                customerViewGrid_CDC[MainGridLastColumn].Width = HiddenColumnWidth;
                customerViewGrid_CDC[MainGridLastColumn].MinWidth = HiddenColumnMinWidth;

                //customerListGrid.SetValue(Grid.ColumnProperty, MainGridFirstColumn);
                Grid.SetColumn(customerListGrid, MainGridFirstColumn);
            }
            else
            {
                /* Sets the customer list to the right side. */

                customerViewGrid_CDC[MainGridLastColumn].Width = customerViewGrid_CDC[MainGridFirstColumn].Width;
                customerViewGrid_CDC[MainGridLastColumn].MinWidth = customerViewGrid_CDC[MainGridFirstColumn].MinWidth;

                customerViewGrid_CDC[MainGridFirstColumn].Width = HiddenColumnWidth;
                customerViewGrid_CDC[MainGridFirstColumn].MinWidth = HiddenColumnMinWidth;

                //customerListGrid.SetValue(Grid.ColumnProperty, MainGridLastColumn);
                Grid.SetColumn(customerListGrid, MainGridLastColumn);
            }
        }
    }
}
