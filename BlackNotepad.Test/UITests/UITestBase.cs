using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace BlackNotepad.Test.UITests
{
    [TestClass]
    public abstract class UITestBase
    {
        protected Application App { get; private set; }

        protected Window MainWindow { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            var outputDir = new DirectoryInfo(
                    Assembly.GetExecutingAssembly().Location).Parent.FullName;
            var appName = $"{Assembly.GetExecutingAssembly().GetName()}"
                .Replace("Test", "exe");
            appName = appName.Remove(appName.IndexOf(','));
            var location = $"{outputDir}\\{appName}";
            App = Application.Launch(location);

            MainWindow = App.GetWindows().FirstOrDefault();
        }

        [TestCleanup]
        public void TearDown()
        {
            App.Close();
            App.Dispose();
        }
    }
}
