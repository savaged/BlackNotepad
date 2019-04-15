using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class ViewStateModel : ObservableObject
    {
        private bool _isWrapped;
        private bool _isStatusBarVisible;
        private int _zoom;

        public bool IsWrapped
        {
            get => _isWrapped;
            set => Set(ref _isWrapped, value);
        }

        public bool IsStatusBarVisible
        {
            get => _isStatusBarVisible;
            set => Set(ref _isStatusBarVisible, value);
        }

        public int Zoom
        {
            get => _zoom;
            set => Set(ref _zoom, value);
        }
    }
}
