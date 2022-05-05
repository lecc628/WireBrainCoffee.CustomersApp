using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        private CustomerItemViewModel? _selectedCustomer;
        private GridLength _gridFirstColumnWidth;
        private double _gridFirstColumnMinWidth;
        private GridLength _gridLastColumnWidth;
        private double _gridLastColumnMinWidth;
        private NavigationSideOption _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;

            SelectedCustomer = null;
            GridFirstColumnWidth = new GridLength(1, GridUnitType.Star);
            GridFirstColumnMinWidth = 250.0;
            GridLastColumnWidth = GridLength.Auto;
            GridLastColumnMinWidth = 0.0;
            NavigationSide = NavigationSideOption.Left;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public GridLength GridFirstColumnWidth
        {
            get => _gridFirstColumnWidth;
            private set
            {
                _gridFirstColumnWidth = value;
                OnPropertyChanged();
            }
        }

        public double GridFirstColumnMinWidth
        {
            get => _gridFirstColumnMinWidth;
            private set
            {
                _gridFirstColumnMinWidth = value;
                OnPropertyChanged();
            }
        }

        public GridLength GridLastColumnWidth
        {
            get => _gridLastColumnWidth;
            private set
            {
                _gridLastColumnWidth = value;
                OnPropertyChanged();
            }
        }

        public double GridLastColumnMinWidth
        {
            get => _gridLastColumnMinWidth;
            private set
            {
                _gridLastColumnMinWidth = value;
                OnPropertyChanged();
            }
        }

        public NavigationSideOption NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
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
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        public void Add()
        {
            var customer = new CustomerItemViewModel(new Customer { FirstName = "New" });
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public void MoveNavigation()
        {
            if (GridFirstColumnMinWidth == Helpful.HiddenColumnMinWidth)
            {
                /* Sets the customers list to the left side. */

                GridFirstColumnWidth = GridLastColumnWidth;
                GridFirstColumnMinWidth = GridLastColumnMinWidth;

                GridLastColumnWidth = Helpful.HiddenColumnWidth;
                GridLastColumnMinWidth = Helpful.HiddenColumnMinWidth;

                //customersListGrid.SetValue(Grid.ColumnProperty, NavigationSideOption.Left);
                NavigationSide = NavigationSideOption.Left;
            }
            else
            {
                /* Sets the customers list to the right side. */

                GridLastColumnWidth = GridFirstColumnWidth;
                GridLastColumnMinWidth = GridFirstColumnMinWidth;

                GridFirstColumnWidth = Helpful.HiddenColumnWidth;
                GridFirstColumnMinWidth = Helpful.HiddenColumnMinWidth;

                //customersListGrid.SetValue(Grid.ColumnProperty, NavigationSideOption.Right);
                NavigationSide = NavigationSideOption.Right;
            }
        }
    }
}
