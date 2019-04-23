namespace Savaged.BlackNotepad.ViewModels
{
    public interface IGoToDialogViewModel : IDialogViewModel
    {
        int LineNumber { get; set; }
    }
}