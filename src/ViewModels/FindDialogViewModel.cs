using GalaSoft.MvvmLight.CommandWpf;
using System;

namespace Savaged.BlackNotepad.ViewModels
{
    public class FindDialogViewModel 
        : ActionDialogViewModelBase, IExclusiveDialogViewModel
    {
        private string _textSought;
        private bool _isFindDirectionUp;
        private bool _isFindMatchCase;
        private bool _isFindWrapAround;

        public Action FindNextRaisedByDialog = delegate { };

        public RelayCommand ReplaceCmd { get; set; }
        public RelayCommand GoToCmd { get; set; }

        public virtual void ResetFilters()
        {
            IsFindDirectionUp = false;
            IsFindMatchCase = false;
            IsFindWrapAround = false;
        }

        public void RaiseFindNext()
        {
            FindNextRaisedByDialog?.Invoke();
        }

        public string TextSought
        {
            get => _textSought;
            set
            {
                Set(ref _textSought, value);
                RaisePropertyChanged(nameof(IsActionEnabled));
            }
        }

        public override bool IsActionEnabled => 
            !string.IsNullOrEmpty(TextSought);

        public bool IsFindDirectionUp
        {
            get => _isFindDirectionUp;
            set => Set(ref _isFindDirectionUp, value);
        }

        public bool IsFindMatchCase
        {
            get => _isFindMatchCase;
            set => Set(ref _isFindMatchCase, value);
        }

        public bool IsFindWrapAround
        {
            get => _isFindWrapAround;
            set => Set(ref _isFindWrapAround, value);
        }
    }
}
