namespace Savaged.BlackNotepad.ViewModels
{
    public class ReplaceDialogViewModel : FindDialogViewModel
    {
        private string _replacementText;

        public string ReplacementText
        {
            get => _replacementText;
            set
            {
                Set(ref _replacementText, value);
                RaisePropertyChanged(nameof(IsReplaceEnabled));
            }
        }

        public bool IsReplaceEnabled =>
            !string.IsNullOrEmpty(ReplacementText);
    }
}
