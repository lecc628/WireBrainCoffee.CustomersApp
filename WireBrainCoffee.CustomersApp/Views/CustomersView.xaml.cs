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
        private readonly CustomersViewModel customersViewModel;

        public CustomersView()
        {
            InitializeComponent();

            customersViewModel = new CustomersViewModel(new CustomerDataProvider());
            DataContext = customersViewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await customersViewModel.LoadAsync();
        }
    }
}
