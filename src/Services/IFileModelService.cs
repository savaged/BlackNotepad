using Savaged.BlackNotepad.Models;
using System.Threading.Tasks;

namespace Savaged.BlackNotepad.Services
{
    public interface IFileModelService
    {
        Task<FileModel> LoadAsync(string location);
        Task SaveAsync(FileModel fileModel);
    }
}