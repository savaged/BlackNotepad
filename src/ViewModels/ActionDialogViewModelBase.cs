namespace Savaged.BlackNotepad.ViewModels
{
    public abstract class ActionDialogViewModelBase 
        : DialogViewModelBase
    {
        public abstract bool IsActionEnabled { get; }
    }
}
