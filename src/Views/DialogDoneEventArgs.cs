using Savaged.BlackNotepad.ViewsInterfaces;
using System;

namespace Savaged.BlackNotepad.Views
{
    public class DialogDoneEventArgs 
        : EventArgs, IDialogDoneEventArgs
    {
        public DialogDoneEventArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }

        public bool? DialogResult { get; }
    }
}
