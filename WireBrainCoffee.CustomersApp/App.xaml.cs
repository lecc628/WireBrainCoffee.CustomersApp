using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.ViewModels;

namespace WireBrainCoffee.CustomersApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }

        private static ServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            services.AddTransient<MainWindow>();

            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomersViewModel>();
            services.AddTransient<ProductsViewModel>();

            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();

            return services.BuildServiceProvider();
        }
    }
}
