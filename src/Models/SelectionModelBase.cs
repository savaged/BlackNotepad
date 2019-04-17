using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public abstract class SelectionModelBase : ObservableObject
    {
        private bool _isSelected;

        public SelectionModelBase(string name, string displayName)
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
