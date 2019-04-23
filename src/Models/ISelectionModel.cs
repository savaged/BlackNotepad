namespace Savaged.BlackNotepad.Models
{
    public interface ISelectionModel
    {
        bool IsSelected { get; set; }

        bool Equals(object o);
        int GetHashCode();
    }
}