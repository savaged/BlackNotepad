using Newtonsoft.Json;
using Savaged.BlackNotepad.Models;
using System;
using System.IO;

namespace Savaged.BlackNotepad.Services
{
    public class ViewStateService : IViewStateService
    {
        private readonly string _fileLocation;

        public ViewStateService()
        {
            var localAppData = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);
            _fileLocation = 
                $"{localAppData}\\BlackNotepad.ViewState.json";
        }

        public ViewStateModel Open()
        {
            ViewStateModel value;
            var fileInfo = new FileInfo(_fileLocation);
            if (fileInfo.Exists)
            {
                value = JsonConvert.DeserializeObject<ViewStateModel>(
                    File.ReadAllText(_fileLocation));
            }
            else
            {
                value = new ViewStateModel();
            }
            return value;
        }

        public void Save(ViewStateModel viewState)
        {
            var json = JsonConvert.SerializeObject(viewState);

            var fileInfo = new FileInfo(_fileLocation);
            if (fileInfo.Exists)
            {
                File.Delete(_fileLocation);
            }
            File.WriteAllText(_fileLocation, json);
        }
    }
}
