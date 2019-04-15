using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.Services
{
    public class ViewStateService : IViewStateService
    {
        public ViewStateModel Open()
        {
            var value = new ViewStateModel();
            return value; // TODO load from disk
        }

        public void Save(ViewStateModel viewState)
        {

        }
    }
}
