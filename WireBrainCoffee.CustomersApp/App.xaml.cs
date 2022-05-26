using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.Model;
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

            services.AddTransient<IDataProvider<Customer>, CustomerDataProvider>();
            services.AddTransient<IDataProvider<Product>, ProductDataProvider>();

            return services.BuildServiceProvider();
        }
    }
}
