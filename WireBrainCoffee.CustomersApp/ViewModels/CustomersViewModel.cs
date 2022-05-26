using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WireBrainCoffee.CustomersApp.Command;
using WireBrainCoffee.CustomersApp.Data;
using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly IDataProvider<Customer> _customerDataProvider;

        private CustomerItemViewModel? _selectedCustomer;
        private GridLength _gridFirstColumnWidth;
        private double _gridFirstColumnMinWidth;
        private GridLength _gridLastColumnWidth;
        private double _gridLastColumnMinWidth;
        private NavigationSideOption _navigationSide;

        public CustomersViewModel(IDataProvider<Customer> customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;

            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);

            SelectedCustomer = null;
            GridFirstColumnWidth = new GridLength(1, GridUnitType.Star);
            GridFirstColumnMinWidth = 250.0;
            GridLastColumnWidth = GridLength.Auto;
            GridLastColumnMinWidth = 0.0;
            NavigationSide = NavigationSideOption.Left;
        }

        public DelegateCommand AddCommand { get; }

        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand MoveNavigationCommand { get; }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.OnCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

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

        public override async Task LoadAsync()
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

        private void Add(object? parameter)
        {
            var customer = new CustomerItemViewModel(new Customer { FirstName = "New" });
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        public void Delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                var pos = Customers.IndexOf(SelectedCustomer);

                Customers.RemoveAt(pos);

                if (pos == Customers.Count) --pos;
                SelectedCustomer = (pos == -1) ? null : Customers[pos];
            }
        }

        public bool CanDelete(object? parameter) => SelectedCustomer is not null;

        private void MoveNavigation(object? parameter)
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
