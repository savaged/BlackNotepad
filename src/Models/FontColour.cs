using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class FontColour : ObservableObject
    {
        private bool _isSelected;

        public FontColour(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
            IsSelected = false;
        }

        public string Name { get; }

        public string DisplayName { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
    }
}
