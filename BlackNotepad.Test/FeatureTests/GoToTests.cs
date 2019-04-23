using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            MainVm.GoToCmd.Execute(2);

            Assert.AreEqual(2, MainVm.CaretLine);
            Assert.AreEqual(1, MainVm.CaretColumn);
        }
    }
}
