using System;
using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class Dialog : Window
    {
        public event EventHandler<DialogDoneEventArgs> DialogDone =
            delegate { };

        public bool IsModal { get; set; }

        protected void RaiseDialogDone(DialogDoneEventArgs e)
        {
            var handler = DialogDone;
            handler?.Invoke(this, e);
        }

        protected virtual void OnCloseCommandExecuted(
            object sender, ExecutedRoutedEventArgs e)
        {
            if (IsModal)
            {
                DialogResult = false;
            }
            else
            {
                RaiseDialogDone(new DialogDoneEventArgs(false));
            }
        }
    }
}
