using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace Savaged.BlackNotepad.ViewModels
{
    public interface IFindDialogViewModel : IExclusiveDialogViewModel
    {
        RelayCommand GoToCmd { get; set; }
        bool IsActionEnabled { get; }
        bool IsFindDirectionUp { get; set; }
        bool IsFindMatchCase { get; set; }
        bool IsFindWrapAround { get; set; }
        RelayCommand ReplaceCmd { get; set; }
        string TextSought { get; set; }

        event EventHandler<FindNextEventArgs> FindNextRaisedByDialog;

        void RaiseFindNext();
    }
}