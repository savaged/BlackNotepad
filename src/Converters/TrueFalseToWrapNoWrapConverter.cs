using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Savaged.BlackNotepad.Converters
{
    class TrueFalseToWrapNoWrapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(TextWrapping))
            {
                throw new ArgumentException(nameof(targetType),
                    "The target type must be TextWrapping");
            }
            TextWrapping wrapping;
            if (value != null && value is bool b && b)
            {
                wrapping = TextWrapping.Wrap;
            }
            else
            {
                wrapping = TextWrapping.NoWrap;
            }
            return wrapping;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}