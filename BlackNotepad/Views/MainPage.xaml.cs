using Savaged.BlackNotepad.ViewModels;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Savaged.BlackNotepad.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            ApplicationView.GetForCurrentView().Title = ViewModel.SelectedItem.Name;

            ContentText.Focus(FocusState.Programmatic);
        }

        private MainPageViewModel ViewModel =>
            ViewModelLocator.Current.MainPageViewModel;

        private void Blacken()
        {
            ContentText.Background = new SolidColorBrush(Colors.Black);
            ContentText.Foreground = new SolidColorBrush(Colors.White);
        }

        private void OnContentTextGotFocus(object sender, RoutedEventArgs e)
        {
            Blacken();
        }

        private void OnContentTextTapped(object sender, TappedRoutedEventArgs e)
        {
            Blacken();
        }
    }
}
