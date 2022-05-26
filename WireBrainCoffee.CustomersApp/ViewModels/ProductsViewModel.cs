using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IDataProvider<Product> _productDataProvider;

        public ProductsViewModel(IDataProvider<Product> productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await _productDataProvider.GetAllAsync();

            if (products is not null)
            {
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
        }
    }
}
