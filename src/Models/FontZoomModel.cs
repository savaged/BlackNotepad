namespace Savaged.BlackNotepad.Models
{
    public class FontZoomModel : SelectionModelBase<int, int>
    {
        public FontZoomModel(int key = 100, int value = 12)
        : base(key, value) { }

        public int Zoom => Key;

        public int FontSize => Value;
    }
}
