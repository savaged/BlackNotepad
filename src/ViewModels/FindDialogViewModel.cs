namespace Savaged.BlackNotepad.ViewModels
{
    public class FindDialogViewModel : ActionDialogViewModelBase
    {
        private string _textSought;

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
    }
}
