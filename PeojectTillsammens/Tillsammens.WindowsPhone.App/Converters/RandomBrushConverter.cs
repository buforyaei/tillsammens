using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Tillsammens.WindowsPhone.App.Converters
{ 
    public class RandomBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var random = new Random();
            var variable = random.Next(1, 5);
             return new SolidColorBrush(Color.FromArgb(220, 132, 43, 43));

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!(value is Visibility)) return DependencyProperty.UnsetValue;
            return (Visibility) value == Visibility.Visible;
        }
    }
}
