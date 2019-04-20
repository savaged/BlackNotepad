using System.Windows;
using System.Windows.Controls;

namespace Savaged.BlackNotepad.Views.Controls
{
    public partial class CancelButtonControl : UserControl
    {
        public CancelButtonControl()
        {
            InitializeComponent();
        }

        protected void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is Dialog dialog)
            {
                if (dialog.IsModal)
                {
                    dialog.DialogResult = false;
                }
                else
                {
                    dialog.RaiseDialogDone(
                        new DialogDoneEventArgs(false));
                }
            }
        }
    }
}
