using System;
using System.Windows;
using Microsoft.Win32;
using Savaged.BlackNotepad.ViewsInterfaces;
using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.Views;

namespace Savaged.BlackNotepad.Services
{
    public interface IDialogService
    {
        T GetDialog<T>() where T : CommonDialog;

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