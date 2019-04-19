using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class Dialog : Window
    {
        protected virtual void OnCloseCommandExecuted(
            object sender, ExecutedRoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
