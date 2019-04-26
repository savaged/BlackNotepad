using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
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
            Thread.Sleep(1000);
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

            Thread.Sleep(1000);
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

            var dialog = windows.Where(w => w.Title == "Go To Line")
                .FirstOrDefault();
            Assert.IsNotNull(dialog);

            var btn = dialog.Get<Button>("CancelButton");
            Assert.IsNotNull(btn);
            btn.Click();

            Thread.Sleep(1000);
            try
            {
                menuItem = menuBar.MenuItem("Edit", "Replace...");
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

            Thread.Sleep(1000);
            windows = App.GetWindows();
            Assert.AreEqual(2, windows.Count);

            dialog = windows.Where(w => w.Title == "Replace")
                .FirstOrDefault();
            Assert.IsNotNull(dialog);

            btn = dialog.Get<Button>("CancelButton");
            Assert.IsNotNull(btn);
            btn.Click();

            Thread.Sleep(1000);
            try
            {
                menuItem = menuBar.MenuItem("Edit", "Time/Date");
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

            Thread.Sleep(1000);
            try
            {
                menuItem = menuBar.MenuItem("Edit", "Find...");
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

            Thread.Sleep(1000);
            windows = App.GetWindows();
            Assert.AreEqual(2, windows.Count);

            dialog = windows.Where(w => w.Title == "Find")
                .FirstOrDefault();
            Assert.IsNotNull(dialog);

            btn = dialog.Get<Button>("CancelButton");
            btn.Click();

            Thread.Sleep(1000);
            try
            {
                menuItem = menuBar.MenuItem("File", "Exit");
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

            Thread.Sleep(1000);
            var msgBox = MainWindow.MessageBox("Black Notepad");
            Assert.IsNotNull(msgBox);
            btn = msgBox.Get<Button>(SearchCriteria.ByText("No"));
            Assert.IsNotNull(btn);
            btn.Click();
        }
    }
}
