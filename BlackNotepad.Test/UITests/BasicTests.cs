using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems.MenuItems;

namespace BlackNotepad.Test.UITests
{
    [TestClass]
    public class BasicTests : UITestBase
    {
        [TestMethod]
        public void StartupTest()
        {
            Assert.IsNotNull(MainWindow);
            var menuBar = MainWindow.MenuBar;
            Assert.IsNotNull(menuBar);
            Thread.Sleep(100);
            Menu menuItem = null;
            try
            {
                menuItem = menuBar.MenuItem("Help", "About");
            }
            catch (AutomationException ex)
            {
                Assert.Fail(
                    "The menu item is not enabled! this may be due to " +
                    "slow running. Try increasing the delay above. " +
                    $"Exception: {ex.Message}");
            }
            Assert.IsNotNull(menuItem);
            menuItem.Click();

            var windows = App.GetWindows();
            Assert.AreEqual(2, windows.Count);
            var win = windows[1];
            Assert.IsNotNull(win);
            Assert.AreEqual("About", win.Title);
            win.Close();
        }

        [TestMethod]
        public void DialogsTest()
        {
            var menuBar = MainWindow.MenuBar;
            Assert.IsNotNull(menuBar);
            Thread.Sleep(100);
            Menu menuItem = null;
            try
            {
                menuItem = menuBar.MenuItem("Edit", "Go To...");
            }
            catch (AutomationException ex)
            {
                Assert.Fail(
                    "The menu item is not enabled! this may be due to " +
                    "slow running. Try increasing the delay above. " +
                    $"Exception: {ex.Message}");
            }
            Assert.IsNotNull(menuItem);
            menuItem.Click();

            var windows = App.GetWindows();
            Assert.AreEqual(2, windows.Count);
            var win = windows[1];
            Assert.IsNotNull(win);
            Assert.AreEqual("Go To...", win.Title);
            win.Close();
        }
    }
}
