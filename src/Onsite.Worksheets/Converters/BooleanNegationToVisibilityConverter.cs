using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Onsite.Worksheets.Converters
{
    /// <summary>
    /// Value converter that translates true to <see cref="Visibility.Collapsed"/> 
    /// and false to <see cref="Visibility.Visible"/>.
    /// </summary>
    public sealed class BooleanNegationToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool convert && !convert) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility visibility && visibility != Visibility.Visible;
        }
    }
}
