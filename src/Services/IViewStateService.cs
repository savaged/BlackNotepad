using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.Services
{
    public interface IViewStateService
    {
        ViewStateModel Open();
        void Save(ViewStateModel viewState);
    }
}