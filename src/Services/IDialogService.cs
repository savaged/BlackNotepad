using System.Windows;
using Savaged.BlackNotepad.ViewModels;

namespace Savaged.BlackNotepad.Services
{
    public interface IDialogService
    {
        T GetDialogViewModel<T>() 
            where T : IDialogViewModel;

        bool? ShowDialog(IDialogViewModel vm);
    }
}