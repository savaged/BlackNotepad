using Savaged.BlackNotepad.ViewsInterfaces;
using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class GoToDialog : Dialog, IModalDialog
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
