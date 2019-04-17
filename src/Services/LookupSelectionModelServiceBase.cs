using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.Services
{
    public abstract class LookupSelectionModelServiceBase<T>
        : LookupServiceBase<T>
        where T : ISelectionModel
    {
    }
}
