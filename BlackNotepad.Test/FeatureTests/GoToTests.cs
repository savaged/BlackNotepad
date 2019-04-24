using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Savaged.BlackNotepad.ViewModels;

namespace BlackNotepad.Test.FeatureTests
{
    [TestClass]
    public class GoToTests : FeatureTestBase
    {
        [TestMethod]
        public void TestGoTo()
        {
            MainVm.SelectedItem.Content =
                "nnnnxxnn\r\nnnnxxnnn\r\nnnnxxn";

            MainVm.GoToRequested += OnGoToRequested;

            var mockGoToVm = new Mock<IGoToDialogViewModel>();
            mockGoToVm.SetupGet(vm => vm.LineNumber).Returns(2);

            MockDialogService.Setup(
                s => s.GetDialogViewModel<IGoToDialogViewModel>())
                .Returns(mockGoToVm.Object);

            MainVm.GoToCmd.Execute(null);
        }

        [TestCleanup]
        public void TearDown()
        {
            MainVm.GoToRequested -= OnGoToRequested;
        }

        private void OnGoToRequested(int start, int selectionLength)
        {
            Assert.AreEqual(2, start);
        }
    }
}
