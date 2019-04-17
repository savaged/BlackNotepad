namespace Savaged.BlackNotepad.ViewModels
{
    public class GoToDialogViewModel : DialogViewModelBase
    {
        private int _lineNumber;

        public int LineNumber
        {
            get => _lineNumber;
            set
            {
                Set(ref _lineNumber, value);
                RaisePropertyChanged(nameof(IsGoToEnabled));
            }
        }

        public bool IsGoToEnabled => LineNumber > 0;
    }
}
