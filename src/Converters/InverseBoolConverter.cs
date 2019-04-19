using System;
using System.Globalization;
using System.Windows.Data;

namespace Savaged.BlackNotepad.Converters
{
    class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (bool)Convert(value, targetType, parameter, culture);
            return !result;
        }
    }
}
