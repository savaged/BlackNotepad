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
            "Nnnnxxnn\r\nNnnnXxnnn\r\nNnnnxxn";
        protected const int DefaultLineToGoTo = 2;
        protected const string DefaultTextSought = "Xx";

        private IDialogService _dialogService;
        private IViewStateService _viewStateService;
        private IFontColourLookupService _fontColourLookupService;
        private IFontFamilyLookupService _fontFamilyLookupService;
        private IFontZoomLookupService _fontZoomLookupService;
        private IFileModelService _fileModelService;

        protected int GoToCaretIndex { get; private set; }

        protected Mock<IDialogService> MockDialogService
        { get; private set; }

        protected MainViewModel MainVm { get; private set; }

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
                s => s.GetDialogViewModel<IFindDialogViewModel>())
                .Returns(findVm);


            var replaceVm = new ReplaceDialogViewModel();
            MockDialogService.Setup(
                s => s.GetDialogViewModel<IReplaceDialogViewModel>())
                .Returns(replaceVm);

            MockDialogService.Setup(
                s => s.ShowDialog(mockGoToVm.Object)).Returns(true);

            _dialogService = MockDialogService.Object;

            var mockFileModelService = new Mock<IFileModelService>();
            // TODO mock Load and Save
            _fileModelService = mockFileModelService.Object;

            MainVm = new MainViewModel(
                _dialogService,
                _viewStateService,
                _fontColourLookupService,
                _fontFamilyLookupService,
                _fontZoomLookupService,
                _fileModelService);

            MainVm.SelectedItem.Content = DefaultContent;

            MainVm.GoToRequested += OnGoToRequested;            
        }

        [TestCleanup]
        public void TearDown()
        {
            MainVm.GoToRequested -= OnGoToRequested;
        }

        private void OnGoToRequested(
            int start, int selectionLength, int line)
        {
            GoToCaretIndex = start;
        }
    }
}
