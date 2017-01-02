using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Tillsammens.WindowsPhone.App.Converters
{
    public class DateTimeToShortFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is DateTime)) return DependencyProperty.UnsetValue;
            DateTime dateTime = DateTime.Parse(value.ToString());
            return dateTime.ToString("g");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
