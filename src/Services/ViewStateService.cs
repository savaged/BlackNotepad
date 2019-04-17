using Newtonsoft.Json;
using Savaged.BlackNotepad.Models;
using System;
using System.IO;

namespace Savaged.BlackNotepad.Services
{
    public class ViewStateService : IViewStateService
    {
        private readonly string _fileLocation;
        private readonly IFontColourLookupService _fontColourLookupService;
        private readonly IFontFamilyLookupService _fontFamilyLookupService;
        private readonly IFontZoomLookupService _fontZoomLookupService;

        public ViewStateService(
            IFontColourLookupService fontColourLookupService,
            IFontFamilyLookupService fontFamilyLookupService,
            IFontZoomLookupService fontZoomLookupService)
        {
            if (fontColourLookupService is null)
            {
                throw new ArgumentNullException(nameof(fontColourLookupService));
            }
            if (fontFamilyLookupService is null)
            {
                throw new ArgumentNullException(nameof(fontFamilyLookupService));
            }
            if (fontZoomLookupService is null)
            {
                throw new ArgumentNullException(nameof(fontZoomLookupService));
            }
            _fontColourLookupService = fontColourLookupService;
            _fontFamilyLookupService = fontFamilyLookupService;
            _fontZoomLookupService = fontZoomLookupService;

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
                value = new ViewStateModel(
                    _fontColourLookupService.GetDefault(),
                    _fontFamilyLookupService.GetDefault(),
                    _fontZoomLookupService.GetDefault());
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
