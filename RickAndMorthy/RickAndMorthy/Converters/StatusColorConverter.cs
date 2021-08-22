using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RickAndMorthy.Cnverters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string) throw new ArgumentException(nameof(value));

            return value.ToString() switch
            {
                "unknown" => Color.Yellow,
                "Alive" => Color.Green,
                _ => Color.Red,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
