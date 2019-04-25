using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.Services
{
    public interface IFileModelService
    {
        FileModel Load(string location);
        void Save(FileModel fileModel);
    }
}