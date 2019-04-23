namespace Savaged.BlackNotepad.Models
{
    public class FontColourModel :
        SelectionModelBase<string, string>
    {
        public FontColourModel(
            string name = "White", 
            string displayName = "White")
        : base(name, displayName) { }
    }
}
