using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class ActionDialog : Dialog
    {
        protected void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
