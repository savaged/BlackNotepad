using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackNotepad.Test.ViewModelTests
{
    [TestClass]
    public class GoToTests : TestBase
    {
        [TestMethod]
        public void TestGoToOnMainViewModel()
        {
            MainVm.GoToCmd.Execute(null);

            Assert.AreEqual(9, GoToCaretIndex);
        }
    }
}
