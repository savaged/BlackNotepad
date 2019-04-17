using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public abstract class SelectionModelBase<TKey, TValue>
        : ObservableObject, ISelectionModel
    {
        private bool _isSelected;
        private TKey _key;
        private TValue _value;

        public SelectionModelBase(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            IsSelected = false;
        }

        public TKey Key
        {
            get => _key;
            set => Set(ref _key, value);
        }

        public TValue Value
        {
            get => _value;
            set => Set(ref _value, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => Set(ref _isSelected, value);
        }
    }
}
