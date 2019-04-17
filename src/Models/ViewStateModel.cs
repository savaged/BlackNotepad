using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Savaged.BlackNotepad.Models
{
    public class ViewStateModel : ObservableObject
    {
        private const int _defaultZoom = 100;
        private readonly IDictionary<int, int> _fontZoom;
        private int _zoom;
        private bool _isWrapped;
        private bool _isStatusBarVisible;
        private FontColourModel _selectedFontColour;
        private FontFamilyModel _selectedFontFamily;

        public ViewStateModel()
        {
            _fontZoom = new Dictionary<int, int>
            {
                //{ 60, 8 },
                //{ 65, 9 },
                //{ 70, 10 },
                //{ 80, 11 },
                //{ 90, 12 },
                //{ _defaultZoom, 14 },
                //{ 115, 16 },
                //{ 130, 18 },
                //{ 145, 20 },
                //{ 160, 22 },
                //{ 170, 24 },
                //{ 190, 26 },
                //{ 200, 28 },
                //{ 260, 36 },
                //{ 300, 42 },
                //{ 345, 48 },
                //{ 515, 72 }
                { 1, 8 },
                { 75, 9 },
                { 80, 10 },
                { 90, 11 },
                { _defaultZoom, 12 },
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
            Zoom = _defaultZoom;
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
            private set
            {
                Set(ref _zoom, value);
                RaisePropertyChanged(nameof(FontSize));
            }
        }

        public int FontSize
        {
            get
            {
                var value = _fontZoom.ContainsKey(Zoom) ?
                    _fontZoom[Zoom] :
                    _fontZoom[_defaultZoom];
                return value;
            }
        }            

        public void ZoomIn()
        {
            int value = _defaultZoom;
            try
            {
                value = _fontZoom.Keys.SkipWhile(i => !i.Equals(Zoom)).Skip(1).First();
            }
            catch (InvalidOperationException)
            {
                value = Zoom;
            }
            Zoom = value;
        }

        public void ZoomOut()
        {
            int value = _defaultZoom;
            try
            {
                value = _fontZoom.Keys.TakeWhile(i => !i.Equals(Zoom)).Last();
            }
            catch (InvalidOperationException)
            {
                value = Zoom;
            }
            Zoom = value;
        }

        public void ZoomDefault()
        {
            Zoom = _defaultZoom;
        }

        public FontColourModel SelectedFontColour
        {
            get => _selectedFontColour;
            set
            {
                value.IsSelected = true;
                Set(ref _selectedFontColour, value);
            }
        }

        public FontFamilyModel SelectedFontFamily
        {
            get => _selectedFontFamily;
            set
            {
                value.IsSelected = true;
                Set(ref _selectedFontFamily, value);
            }
        }
    }
}
