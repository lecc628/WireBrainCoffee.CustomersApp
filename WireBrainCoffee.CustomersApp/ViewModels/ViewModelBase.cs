﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WireBrainCoffee.CustomersApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //
        // Summary:
        //     Occurs when a property value changes.
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
