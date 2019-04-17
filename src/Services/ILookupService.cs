using System.Collections.Generic;

namespace Savaged.BlackNotepad.Services
{
    public interface ILookupService<T>
    {
        T GetDefault();
        IList<T> GetIndex();
    }
}