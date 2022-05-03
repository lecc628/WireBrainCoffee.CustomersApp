using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.ViewModel;

namespace WireBrainCoffee.CustomersApp.Views
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml.
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public static readonly int CustomersViewFirstColumn = 0;
        public static readonly int CustomersViewLastColumn = 2;

        private readonly CustomersViewModel customersViewModel;
        private readonly ColumnDefinitionCollection customersViewGrid_CDC;

        public CustomersView()
        {
            InitializeComponent();
            customersViewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = customersViewModel;
            Loaded += CustomersView_Loaded;

            customersViewGrid_CDC = customersViewGrid.ColumnDefinitions;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await customersViewModel.LoadAsync();
        }

        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            if (customersViewGrid_CDC[CustomersViewFirstColumn].MinWidth == Helpful.HiddenColumnMinWidth)
            {
                /* Sets the customers list to the left side. */

                customersViewGrid_CDC[CustomersViewFirstColumn].Width = customersViewGrid_CDC[CustomersViewLastColumn].Width;
                customersViewGrid_CDC[CustomersViewFirstColumn].MinWidth = customersViewGrid_CDC[CustomersViewLastColumn].MinWidth;

                customersViewGrid_CDC[CustomersViewLastColumn].Width = Helpful.HiddenColumnWidth;
                customersViewGrid_CDC[CustomersViewLastColumn].MinWidth = Helpful.HiddenColumnMinWidth;

                //customersListGrid.SetValue(Grid.ColumnProperty, CustomersViewFirstColumn);
                Grid.SetColumn(customersListGrid, CustomersViewFirstColumn);
            }
            else
            {
                /* Sets the customers list to the right side. */

                customersViewGrid_CDC[CustomersViewLastColumn].Width = customersViewGrid_CDC[CustomersViewFirstColumn].Width;
                customersViewGrid_CDC[CustomersViewLastColumn].MinWidth = customersViewGrid_CDC[CustomersViewFirstColumn].MinWidth;

                customersViewGrid_CDC[CustomersViewFirstColumn].Width = Helpful.HiddenColumnWidth;
                customersViewGrid_CDC[CustomersViewFirstColumn].MinWidth = Helpful.HiddenColumnMinWidth;

                //customersListGrid.SetValue(Grid.ColumnProperty, CustomersViewLastColumn);
                Grid.SetColumn(customersListGrid, CustomersViewLastColumn);
            }
        }
    }
}
