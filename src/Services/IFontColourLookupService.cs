using Savaged.BlackNotepad.Models;
using System.Collections.Generic;

namespace Savaged.BlackNotepad.Services
{
    public interface IFontColourLookupService
    {
        FontColourModel GetDefault();
        IList<FontColourModel> GetIndex();
    }
}