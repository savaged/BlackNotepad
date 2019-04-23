namespace Savaged.BlackNotepad.Models
{
    public class FontFamilyModel :
        SelectionModelBase<string, string>
    {
        public FontFamilyModel(
            string name = "Arial", 
            string displayName = "Arial")
        : base (name, displayName) { }
    }
}
