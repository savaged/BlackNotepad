using GalaSoft.MvvmLight.Ioc;

namespace Savaged.BlackNotepad.ViewModels
{
    [Windows.UI.Xaml.Data.Bindable]
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current => _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        public MainPageViewModel MainPageViewModel => 
            SimpleIoc.Default.GetInstance<MainPageViewModel>();
    }
}
