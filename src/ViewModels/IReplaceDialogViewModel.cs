using System;
using GalaSoft.MvvmLight.CommandWpf;

namespace Savaged.BlackNotepad.ViewModels
{
    public interface IReplaceDialogViewModel : IFindDialogViewModel
    {
        RelayCommand FindCmd { get; set; }
        bool IsReplaceEnabled { get; }
        string ReplacementText { get; set; }

        event EventHandler<FindNextEventArgs> ReplaceAllRaisedByDialog;
        event EventHandler<FindNextEventArgs> ReplaceRaisedByDialog;

        void RaiseReplace();
        void RaiseReplaceAll();
    }
}