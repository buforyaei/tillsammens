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
            var variable = 0;
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                variable = random.Next(0, 5);
            }
            if (variable == 1) return new SolidColorBrush(Color.FromArgb(220, 132, 43, 43));
            if (variable == 2) return new SolidColorBrush(Color.FromArgb(220, 43, 73, 132));
            if (variable == 3) return new SolidColorBrush(Color.FromArgb(220, 43, 123, 102));
            if (variable == 4) return new SolidColorBrush(Color.FromArgb(220, 203, 141, 49));
            return new SolidColorBrush(Color.FromArgb(220, 175, 68, 111));

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (!(value is Visibility)) return DependencyProperty.UnsetValue;
            return (Visibility) value == Visibility.Visible;
        }
    }
}
