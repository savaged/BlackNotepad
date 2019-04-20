using System;

namespace Savaged.BlackNotepad.Views
{
    public class DialogDoneEventArgs : EventArgs
    {
        public DialogDoneEventArgs(bool? dialogResult)
        {
            DialogResult = dialogResult;
        }

        public bool? DialogResult { get; }
    }
}
