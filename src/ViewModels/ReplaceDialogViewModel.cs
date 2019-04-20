using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace Savaged.BlackNotepad.ViewModels
{
    public class ReplaceDialogViewModel : FindDialogViewModel
    {
        private string _replacementText;

        public Action ReplaceRaisedByDialog = delegate { };
        public Action ReplaceAllRaisedByDialog = delegate { };

        public RelayCommand FindCmd { get; set; }

        public void RaiseReplace()
        {
            var handler = ReplaceRaisedByDialog;
            handler?.Invoke();
        }

        public void RaiseReplaceAll()
        {
            var handler = ReplaceAllRaisedByDialog;
            handler?.Invoke();
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
            !string.IsNullOrEmpty(ReplacementText);
    }
}
