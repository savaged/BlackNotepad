using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Savaged.BlackNotepad.Converters
{
    public class CoordsToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null
                || value.GetType() != typeof(ValueTuple<int, int>)
                || targetType != typeof(string))
            {
                return string.Empty;
            }
            var coords = (ValueTuple<int, int>)value;
            var output = $"Ln {coords.Item2}, Col {coords.Item1}";
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
