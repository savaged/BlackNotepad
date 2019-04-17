using Savaged.BlackNotepad.Models;
using System.Linq;
using System.Windows.Media;

namespace Savaged.BlackNotepad.Services
{
    public class FontFamilyLookupService :
        LookupServiceBase<FontFamilyModel>, IFontFamilyLookupService
    {
        private const string _default = "Arial Unicode MS";

        public FontFamilyLookupService() : base()
        {
            foreach (var fontFamily in Fonts.SystemFontFamilies)
            {
                var name = fontFamily.ToString();
                Index.Add(new FontFamilyModel(name, name));
            }
        }

        public override FontFamilyModel GetDefault()
        {
            var value = Index.Where(f => f.Key == _default).FirstOrDefault();
            return value;
        }
    }
}
