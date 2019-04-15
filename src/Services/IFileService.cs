using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.Services
{
    public interface IFileService
    {
        FileModel Open();
        void Save();
    }
}