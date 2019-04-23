using Microsoft.Win32;
using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.ViewsInterfaces;
using System;

namespace Savaged.BlackNotepad.Services
{
    public interface IDialogService
    {
        T GetFileDialog<T>() where T : FileDialog;

        T GetDialogViewModel<T>() 
            where T : IDialogViewModel;

        void Show(IDialogViewModel vm);

        bool? ShowDialog(IDialogViewModel vm);

        bool? ShowDialog(
            string msg,
            string title,
            bool yesNoButtons = false,
            bool yesNoCancelButtons = false);

        event EventHandler<IDialogDoneEventArgs> DialogDone;
    }
}