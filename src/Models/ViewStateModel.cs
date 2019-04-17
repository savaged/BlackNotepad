using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class ViewStateModel : ObservableObject
    {
        private bool _isWrapped;
        private bool _isStatusBarVisible;
        private FontZoomModel _selectedFontZoom;
        private FontColourModel _selectedFontColour;
        private FontFamilyModel _selectedFontFamily;

        public ViewStateModel(
            FontColourModel defaultFontColour,
            FontFamilyModel defaultFontFamily,
            FontZoomModel defaultFontZoom)
        {
            SelectedFontColour = 
                defaultFontColour ?? new FontColourModel { IsSelected = true };
            SelectedFontFamily = 
                defaultFontFamily ?? new FontFamilyModel { IsSelected = true };
            SelectedFontZoom = 
                defaultFontZoom ?? new FontZoomModel { IsSelected = true };
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

        public FontZoomModel SelectedFontZoom
        {
            get => _selectedFontZoom;
            set
            {
                Set(ref _selectedFontZoom, value);
            }
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
