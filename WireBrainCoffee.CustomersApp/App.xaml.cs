using System.Windows;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.ViewModels;

namespace WireBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = new MainWindow(new MainViewModel(
                new CustomersViewModel(new CustomerDataProvider()),
                new ProductsViewModel()
            ));
            mainWindow.Show();
        }
    }
}
