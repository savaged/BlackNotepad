namespace Savaged.BlackNotepad.ViewModels
{
    public class GoToDialogViewModel
        : ActionDialogViewModelBase, IGoToDialogViewModel
    {
        private int _lineNumber;

        public int LineNumber
        {
            get => _lineNumber;
            set
            {
                Set(ref _lineNumber, value);
                RaisePropertyChanged(nameof(IsActionEnabled));
            }
        }

        public override bool IsActionEnabled => LineNumber > 0;
    }
}
