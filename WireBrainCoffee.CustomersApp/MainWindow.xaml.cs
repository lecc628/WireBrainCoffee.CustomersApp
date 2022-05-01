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

        private readonly ColumnDefinitionCollection mainGrid_CDC;

        public MainWindow()
        {
            InitializeComponent();

            mainGrid_CDC = mainGrid.ColumnDefinitions;
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            if (mainGrid_CDC[MainGridFirstColumn].MinWidth == HiddenColumnMinWidth)
            {
                /* Sets the customer list to the left side. */

                mainGrid_CDC[MainGridFirstColumn].Width = mainGrid_CDC[MainGridLastColumn].Width;
                mainGrid_CDC[MainGridFirstColumn].MinWidth = mainGrid_CDC[MainGridLastColumn].MinWidth;

                mainGrid_CDC[MainGridLastColumn].Width = HiddenColumnWidth;
                mainGrid_CDC[MainGridLastColumn].MinWidth = HiddenColumnMinWidth;

                customerListGrid.SetValue(Grid.ColumnProperty, MainGridFirstColumn);
            }
            else
            {
                /* Sets the customer list to the right side. */

                mainGrid_CDC[MainGridLastColumn].Width = mainGrid_CDC[MainGridFirstColumn].Width;
                mainGrid_CDC[MainGridLastColumn].MinWidth = mainGrid_CDC[MainGridFirstColumn].MinWidth;

                mainGrid_CDC[MainGridFirstColumn].Width = HiddenColumnWidth;
                mainGrid_CDC[MainGridFirstColumn].MinWidth = HiddenColumnMinWidth;

                customerListGrid.SetValue(Grid.ColumnProperty, MainGridLastColumn);
            }
        }
    }
}
