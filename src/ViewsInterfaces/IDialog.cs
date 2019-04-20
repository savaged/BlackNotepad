using System;

namespace Savaged.BlackNotepad.ViewsInterfaces
{
    public interface IDialog
    {
        bool IsModal { get; set; }

        event EventHandler<IDialogDoneEventArgs> DialogDone;

        object DataContext { get; }
    }
}