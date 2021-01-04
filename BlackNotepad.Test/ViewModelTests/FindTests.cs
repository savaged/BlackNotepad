using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.BlackNotepad.ViewModels;

namespace BlackNotepad.Test.ViewModelTests
{
    [TestClass]
    public class FindTests : TestBase
    {
        private IFindDialogViewModel _findVm;

        [TestInitialize]
        public void SetUp()
        {
            _findVm = MockDialogService.Object
                .GetDialogViewModel<IFindDialogViewModel>();
        }

        [TestMethod]
        public void TestFindOnMainViewModel()
        {
            MainVm.FindCmd.Execute(null);
            _findVm.TextSought = DefaultTextSought;
            _findVm.RaiseFindNext();

            Assert.AreEqual(4, GoToCaretIndex, "Caret Index");
        }

        [TestMethod]
        public void TestCaseSensitiveFindOnMainViewModel()
        {
            MainVm.FindCmd.Execute(null);
            _findVm.TextSought = DefaultTextSought;
            _findVm.IsFindMatchCase = true;
            _findVm.RaiseFindNext();

            Assert.AreEqual(14, GoToCaretIndex, "Caret Index");
        }
    }
}
