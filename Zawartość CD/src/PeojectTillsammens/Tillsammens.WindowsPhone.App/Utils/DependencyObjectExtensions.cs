using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Tillsammens.WindowsPhone.App.Utils
{
    public static class DependencyObjectExtensions
    {
        public static T GetChildOfType<T>(this DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        public static IEnumerable<T> GetChildrenOfType<T>(this DependencyObject depObj)
            where T : DependencyObject
        {
            if (depObj == null) return null;
            var children = new List<T>();
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) children.Add(result);
            }
            return children;
        }

        public static T GetParent<T>(this DependencyObject child) where T : DependencyObject
        {
            while (!(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }

            return (T)child;
        }
    }
}
