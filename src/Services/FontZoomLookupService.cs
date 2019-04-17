using Savaged.BlackNotepad.Models;
using System.Linq;

namespace Savaged.BlackNotepad.Services
{
    public class FontZoomLookupService :
        LookupSelectionModelServiceBase<FontZoomModel>, IFontZoomLookupService
    {
        private const int _default = 100;

        public FontZoomLookupService() : base()
        {
            Index.Add(new FontZoomModel(1, 8));
            Index.Add(new FontZoomModel(75, 9));
            Index.Add(new FontZoomModel(80, 10));
            Index.Add(new FontZoomModel(90, 11));
            Index.Add(new FontZoomModel(_default, 12));
            Index.Add(new FontZoomModel(120, 14));
            Index.Add(new FontZoomModel(130, 16));
            Index.Add(new FontZoomModel(150, 18));
            Index.Add(new FontZoomModel(170, 20));
            Index.Add(new FontZoomModel(180, 22));
            Index.Add(new FontZoomModel(200, 24));
            Index.Add(new FontZoomModel(220, 26));
            Index.Add(new FontZoomModel(230, 28));
            Index.Add(new FontZoomModel(300, 36));
            Index.Add(new FontZoomModel(350, 42));
            Index.Add(new FontZoomModel(400, 48));
            Index.Add(new FontZoomModel(600, 72));
        }

        public override FontZoomModel GetDefault()
        {
            var value = Index.Where(f => f.Key == _default).FirstOrDefault();
            return value;
        }
    }
}
