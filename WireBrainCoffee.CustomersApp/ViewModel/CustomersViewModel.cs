using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        private Customer? _selectedCustomer;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        public ObservableCollection<Customer> Customers { get; } = new();

        public Customer? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();

            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(customer);
                }
            }
        }

        public void Add()
        {
            var customer = new Customer { FirstName = "New" };
            Customers.Add(customer);
            SelectedCustomer = customer;
        }
    }
}
