using GalaSoft.MvvmLight;
using System;

namespace Savaged.BlackNotepad.Models
{
    public abstract class SelectionModelBase<TKey, TValue>
        : ObservableObject, IEquatable<SelectionModelBase<TKey, TValue>>, ISelectionModel
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

        public override int GetHashCode()
        {
            var value = Key.GetHashCode();
            value *= 0x00010000;
            value *= Value.GetHashCode();
            return value;
        }

        public override bool Equals(object o)
        {
            return Equals(o as SelectionModelBase<TKey, TValue>);
        }

        public bool Equals(SelectionModelBase<TKey, TValue> s)
        {
            // If parameter is null, return false.
            if (s is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (object.ReferenceEquals(this, s))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (GetType() != s.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.
            return (Key.ToString() == s.Key.ToString()) &&
                (Value.ToString() == s.Value.ToString());
        }
    }
}
