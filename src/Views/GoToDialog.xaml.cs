using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class GoToDialog : Dialog
    {
        public GoToDialog()
        {
            InitializeComponent();
        }

        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
