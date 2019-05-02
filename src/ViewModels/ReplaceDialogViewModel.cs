using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace Savaged.BlackNotepad.ViewModels
{
    public class ReplaceDialogViewModel 
        : FindDialogViewModel, IReplaceDialogViewModel
    {
        private string _replacementText;

        public event EventHandler<FindNextEventArgs> 
            ReplaceRaisedByDialog = delegate { };

        public event EventHandler<FindNextEventArgs> 
            ReplaceAllRaisedByDialog = delegate { };

        public RelayCommand FindCmd { get; set; }

        public void RaiseReplace()
        {
            ReplaceRaisedByDialog?.Invoke(
                this,
                new FindNextEventArgs(
                    IsFindWrapAround, IsFindMatchCase));
        }

        public void RaiseReplaceAll()
        {
            ReplaceAllRaisedByDialog?.Invoke(
                this,
                new FindNextEventArgs(
                    IsFindWrapAround, IsFindMatchCase));
        }

        public string ReplacementText
        {
            get => _replacementText;
            set
            {
                Set(ref _replacementText, value);
                RaisePropertyChanged(nameof(IsReplaceEnabled));
            }
        }

        public bool IsReplaceEnabled => IsActionEnabled &&
            ReplacementText != null;
    }
}
