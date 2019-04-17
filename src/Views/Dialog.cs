using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class Dialog : Window
    {
        protected void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        protected void OnCloseCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
