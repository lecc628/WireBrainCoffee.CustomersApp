﻿using System.Threading.Tasks;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly CustomersViewModel _customersViewModel;
        private readonly ProductsViewModel _productsViewModel;
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            _customersViewModel = customersViewModel;
            _productsViewModel = productsViewModel;
            SelectedViewModel = _customersViewModel;
        }

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
    }
}
