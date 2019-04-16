using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class FontZoomModel : ObservableObject
    {
        public int Key { get; }

        public int FontSize { get; }

        public int Zoom { get; }
    }
}
