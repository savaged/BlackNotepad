using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackNotepad.Test.ViewModelTests
{
    [TestClass]
    public class GoToTests : TestBase
    {
        private int _goToCaretIndex;

        [TestInitialize]
        public void SetUp()
        {
            MainVm.SelectedItem.Content = DefaultContent;
        }

        [TestCleanup]
        public void TearDown()
        {
            MainVm.GoToRequested -= OnGoToRequested;
        }

        [TestMethod]
        public void TestGoToOnMainViewModel()
        {
            MainVm.GoToRequested += OnGoToRequested;

            MainVm.GoToCmd.Execute(null);

            Assert.AreEqual(9, _goToCaretIndex);
        }

        private void OnGoToRequested(int start, int selectionLength)
        {
            _goToCaretIndex = start;
        }
    }
}
