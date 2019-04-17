using Savaged.BlackNotepad.Models;
using System.Linq;

namespace Savaged.BlackNotepad.Services
{
    public class FontColourLookupService :
        LookupServiceBase<FontColourModel>, IFontColourLookupService
    {
        private const string _default = "White";

        public FontColourLookupService() : base()
        {
            Index.Add(new FontColourModel("LightGreen", "Light Green"));
            Index.Add(new FontColourModel("White", "White"));
        }

        public override FontColourModel GetDefault()
        {
            var value = Index.Where(f => f.Key == _default).FirstOrDefault();
            return value;
        }
    }
}
