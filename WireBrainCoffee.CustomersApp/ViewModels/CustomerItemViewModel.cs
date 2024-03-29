﻿using WireBrainCoffee.CustomersApp.Model;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                OnPropertyChanged();

                if (string.IsNullOrEmpty(_model.FirstName))
                {
                    AddError("Firstname is require");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                OnPropertyChanged();

                if (string.IsNullOrEmpty(_model.LastName))
                {
                    AddError("Lastname is require");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                OnPropertyChanged();
            }
        }
    }
}
