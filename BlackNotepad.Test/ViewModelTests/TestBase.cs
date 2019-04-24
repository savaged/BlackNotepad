using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Moq;
using Savaged.BlackNotepad.Models;
using Savaged.BlackNotepad.Services;
using Savaged.BlackNotepad.ViewModels;

namespace BlackNotepad.Test.ViewModelTests
{
    [TestClass]
    public abstract class TestBase
    {
        protected const string DefaultContent =
            "nnnnxxnn\r\n\nnnnxxnnn\r\n\nnnnxxn";
        protected const int DefaultLineToGoTo = 2;

        private IDialogService _dialogService;
        private IViewStateService _viewStateService;
        private IFontColourLookupService _fontColourLookupService;
        private IFontFamilyLookupService _fontFamilyLookupService;
        private IFontZoomLookupService _fontZoomLookupService;

        /// <summary>
        /// NOTE: 
        /// Uses ref to presentationframework.dll for common dialogs
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _fontZoomLookupService = new FontZoomLookupService();
            _fontFamilyLookupService = new FontFamilyLookupService();
            _fontColourLookupService = new FontColourLookupService();

            var exampleViewStateModel = new ViewStateModel(
                _fontColourLookupService.GetDefault(),
                _fontFamilyLookupService.GetDefault(),
                _fontZoomLookupService.GetDefault());

            var mockViewStateService = new Mock<IViewStateService>();
            mockViewStateService.Setup(s => s.Open())
                .Returns(exampleViewStateModel);
            _viewStateService = mockViewStateService.Object;


            MockDialogService = new Mock<IDialogService>();
            MockDialogService.Setup(
                s => s.GetFileDialog<OpenFileDialog>())
                .Returns(It.IsAny<OpenFileDialog>());
            MockDialogService.Setup(
                s => s.GetFileDialog<SaveFileDialog>())
                .Returns(It.IsAny<SaveFileDialog>());


            var mockGoToVm = new Mock<IGoToDialogViewModel>();
            mockGoToVm.SetupGet(vm => vm.LineNumber)
                .Returns(DefaultLineToGoTo);

            MockDialogService.Setup(
                s => s.GetDialogViewModel<IGoToDialogViewModel>())
                .Returns(mockGoToVm.Object);

            var findVm = new FindDialogViewModel();
            MockDialogService.Setup(
                s => s.GetDialogViewModel<FindDialogViewModel>())
                .Returns(findVm);

            var replaceVm = new ReplaceDialogViewModel();
            MockDialogService.Setup(
                s => s.GetDialogViewModel<ReplaceDialogViewModel>())
                .Returns(replaceVm);

            MockDialogService.Setup(
                s => s.ShowDialog(mockGoToVm.Object)).Returns(true);

            _dialogService = MockDialogService.Object;

            MainVm = new MainViewModel(
                _dialogService,
                _viewStateService,
                _fontColourLookupService,
                _fontFamilyLookupService,
                _fontZoomLookupService);
        }

        protected Mock<IDialogService> MockDialogService
        { get; private set; }
        protected MainViewModel MainVm { get; private set; }
    }
}
