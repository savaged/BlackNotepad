using Savaged.BlackNotepad.Lookups;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Savaged.BlackNotepad.Converters
{
    public class LineEndingEnumToDisplayNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null 
                || value.GetType() != typeof(LineEndings)
                || targetType != typeof(string))
            {
                return string.Empty;
            }
            if (value is LineEndings l)
            {
                if (l == LineEndings.CRLF)
                {
                    return "Windows (CRLF)";
                }
                if (l == LineEndings.LF)
                {
                    return "Mac (LF)";
                }
                if (l == LineEndings.CR)
                {
                    return "Unix (CR)";
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
