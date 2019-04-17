using Savaged.BlackNotepad.Models;
using System.Collections.Generic;

namespace Savaged.BlackNotepad.Services
{
    public interface IFontFamilyLookupService
    {
        FontFamilyModel GetDefault();
        IList<FontFamilyModel> GetIndex();
    }
}