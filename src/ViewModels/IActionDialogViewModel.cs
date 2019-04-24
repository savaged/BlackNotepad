namespace Savaged.BlackNotepad.ViewModels
{
    public interface IActionDialogViewModel 
        : IDialogViewModel
    {
        bool IsActionEnabled { get; }
    }
}