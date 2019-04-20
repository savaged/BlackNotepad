using Savaged.BlackNotepad.ViewsInterfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class Dialog : Window, IDialog
    {
        public bool IsModal { get; set; }

        public event EventHandler<IDialogDoneEventArgs> DialogDone =
            delegate { };

        public void RaiseDialogDone(IDialogDoneEventArgs e)
        {
            DialogDone?.Invoke(this, e);
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
