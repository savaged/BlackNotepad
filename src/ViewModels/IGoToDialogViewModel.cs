namespace Savaged.BlackNotepad.ViewModels
{
    public interface IGoToDialogViewModel : IActionDialogViewModel
    {
        int LineNumber { get; set; }
    }
}