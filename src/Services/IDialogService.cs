using System.Windows;
using Microsoft.Win32;
using Savaged.BlackNotepad.ViewModels;

namespace Savaged.BlackNotepad.Services
{
    public interface IDialogService
    {
        T GetDialog<T>() where T : CommonDialog;

        T GetDialogViewModel<T>() 
            where T : IDialogViewModel;

        bool? ShowDialog(IDialogViewModel vm);

        bool? ShowDialog(
            string msg,
            string title,
            bool yesNoButtons = false,
            bool yesNoCancelButtons = false);
    }
}