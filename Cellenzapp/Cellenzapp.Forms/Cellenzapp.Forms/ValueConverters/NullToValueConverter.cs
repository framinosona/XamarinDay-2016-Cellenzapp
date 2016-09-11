using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cellenzapp.Forms.ValueConverters
{
    public class NullToValueConverter : IValueConverter
    {
        public object ValueIfNull { get; set; }
        public object ValueIfNotNull { get; set; } = null;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is String && String.IsNullOrWhiteSpace((string)value))
                return ValueIfNull;
            else if (value == null)
                return ValueIfNull;
            else if (parameter != null)
                return parameter;
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
