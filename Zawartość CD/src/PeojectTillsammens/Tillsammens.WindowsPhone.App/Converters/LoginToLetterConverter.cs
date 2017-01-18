using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Tillsammens.WindowsPhone.App.Converters
{
    public class LoginToLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;
            var login = (string) value;
            return login.ToUpper().ToArray()[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!(value is string)) return DependencyProperty.UnsetValue;
            var login = (string)value;
            return login.ToUpper().ToArray()[0];
        }
    }
}
