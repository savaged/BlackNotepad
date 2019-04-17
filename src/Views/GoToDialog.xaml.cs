using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class GoToDialog : Window
    {
        public GoToDialog()
        {
            InitializeComponent();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OnGoToButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
