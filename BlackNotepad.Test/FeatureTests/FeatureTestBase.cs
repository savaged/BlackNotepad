using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using Moq;
using Savaged.BlackNotepad.Models;
using Savaged.BlackNotepad.Services;
using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.ViewsInterfaces;

namespace BlackNotepad.Test.FeatureTests
{
    [TestClass]
    public abstract class FeatureTestBase
    {
        private IDialogService _dialogService;
        private IViewStateService _viewStateService;
        private IFontColourLookupService _fontColourLookupService;
        private IFontFamilyLookupService _fontFamilyLookupService;
        private IFontZoomLookupService _fontZoomLookupService;

        protected Mock<IDialogService> MockDialogService;

        /// <summary>
        /// NOTE: 
        /// Uses ref to presentationframework.dll for common dialogs
        /// </summary>
        [TestInitialize]
        public void Setup()
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


            var goToVm = new GoToDialogViewModel();

            MockDialogService.Setup(
                s => s.GetDialogViewModel<IGoToDialogViewModel>())
                .Returns(goToVm);

            MockDialogService.Setup(
                s => s.ShowDialog(goToVm)).Returns(true);


            // TODO mock each view model

            _dialogService = MockDialogService.Object;

            MainVm = new MainViewModel(
                _dialogService,
                _viewStateService,
                _fontColourLookupService,
                _fontFamilyLookupService,
                _fontZoomLookupService);
        }

        protected MainViewModel MainVm { get; private set; }
    }
}
