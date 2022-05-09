using System.Threading.Tasks;
using WireBrainCoffee.CustomersApp.Command;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);

            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = CustomersViewModel;
        }

        public DelegateCommand SelectViewModelCommand { get; }

        public CustomersViewModel CustomersViewModel { get; }

        public ProductsViewModel ProductsViewModel { get; }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
