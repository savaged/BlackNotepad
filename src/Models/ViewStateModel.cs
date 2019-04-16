using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace Savaged.BlackNotepad.Models
{
    public class ViewStateModel : ObservableObject
    {
        private readonly IDictionary<int, int> _fontZoom;
        private bool _isWrapped;
        private bool _isStatusBarVisible;
        private int _zoom;
        private FontColour _selectedFontColour;

        public ViewStateModel()
        {
            _fontZoom = new Dictionary<int, int>
            {
                { 1, 8 },
                { 75, 9 },
                { 80, 10 },
                { 90, 11 },
                { 100, 12 },
                { 120, 14 },
                { 130, 16 },
                { 150, 18 },
                { 170, 20 },
                { 180, 22 },
                { 200, 24 },
                { 220, 26 },
                { 230, 28 },
                { 300, 36 },
                { 350, 42 },
                { 400, 48 },
                { 600, 72 }
            };
        }

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
            set
            {
                Set(ref _zoom, value);
                RaisePropertyChanged(nameof(FontSize));
            }
        } //TODO fix this
        public int FontSize => _fontZoom.ContainsKey(Zoom) ? _fontZoom[Zoom] : 12;

        public FontColour SelectedFontColour
        {
            get => _selectedFontColour;
            set
            {
                value.IsSelected = true;
                Set(ref _selectedFontColour, value);
            }
        }
    }
}
