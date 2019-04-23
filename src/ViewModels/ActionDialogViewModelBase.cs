namespace Savaged.BlackNotepad.ViewModels
{
    public abstract class ActionDialogViewModelBase
        : DialogViewModelBase, IActionDialogViewModel
    {
        public abstract bool IsActionEnabled { get; }
    }
}
