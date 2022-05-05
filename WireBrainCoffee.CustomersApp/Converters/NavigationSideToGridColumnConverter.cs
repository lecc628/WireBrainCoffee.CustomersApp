using System;
using System.Globalization;
using System.Windows.Data;

namespace WireBrainCoffee.CustomersApp.Converters
{
    public class NavigationSideToGridColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (NavigationSideOption)value;

            return ((navigationSide == NavigationSideOption.Left)
                ? 0  /* First column of the CustomersView grid. */
                : 2  /* Last column of the CustomersView grid. */
                );
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
