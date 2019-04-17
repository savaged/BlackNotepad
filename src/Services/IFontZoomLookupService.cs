using Savaged.BlackNotepad.Models;
using System.Collections.Generic;

namespace Savaged.BlackNotepad.Services
{
    public interface IFontZoomLookupService
    {
        FontZoomModel GetDefault();
        IList<FontZoomModel> GetIndex();
    }
}