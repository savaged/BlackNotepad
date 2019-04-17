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
            Close();
        }
    }
}
