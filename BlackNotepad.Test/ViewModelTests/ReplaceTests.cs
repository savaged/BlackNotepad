using Microsoft.VisualStudio.TestTools.UnitTesting;
using Savaged.BlackNotepad.ViewModels;

namespace BlackNotepad.Test.ViewModelTests
{
    [TestClass]
    public class ReplaceTests : TestBase
    {
        private IReplaceDialogViewModel _replace;
        private const string _replacementText = "ok";

        [TestInitialize]
        public void SetUp()
        {
            _replace = MockDialogService.Object
                .GetDialogViewModel<IReplaceDialogViewModel>();
        }

        [TestMethod]
        public void TestReplaceOnMainViewModel()
        {
            MainVm.ReplaceCmd.Execute(null);
            _replace.TextSought = DefaultTextSought;
            _replace.ReplacementText = _replacementText;
            // Emulate the find operation of the dialog
            _replace.RaiseReplace();
            // Now do the replacement
            _replace.RaiseReplace();

            var text = MainVm.SelectedItem.Content;
            Assert.IsTrue(text.Contains(_replacementText));
            // Test it only removed the first
            Assert.IsTrue(text.Contains(DefaultTextSought));
        }

        [TestMethod]
        public void TestCaseSensitiveReplaceOnMainViewModel()
        {
            const string sought = "Nn";
            MainVm.ReplaceCmd.Execute(null);
            _replace.TextSought = sought;
            _replace.ReplacementText = _replacementText;
            _replace.IsFindMatchCase = true;
            // Emulate the find operation of the dialog
            _replace.RaiseReplace();
            // Now do the replacement
            _replace.RaiseReplace();

            var text = MainVm.SelectedItem.Content;
            Assert.IsTrue(text.Contains(_replacementText));
            // Test it only removed the first
            Assert.IsTrue(text.Contains(sought));
        }

        [TestMethod]
        public void TestReplaceAllOnMainViewModel()
        {
            MainVm.ReplaceCmd.Execute(null);
            _replace.TextSought = DefaultTextSought;
            _replace.ReplacementText = _replacementText;
            _replace.RaiseReplaceAll();

            var text = MainVm.SelectedItem.Content;
            Assert.IsTrue(text.Contains(_replacementText));
            Assert.IsFalse(text.Contains(DefaultTextSought));
        }

        [TestMethod]
        public void TestCaseSensitiveReplaceAllOnMainViewModel()
        {
            const string sought = "Nn";
            MainVm.ReplaceCmd.Execute(null);
            _replace.TextSought = sought;
            _replace.ReplacementText = _replacementText;
            _replace.IsFindMatchCase = true;
            _replace.RaiseReplaceAll();

            var text = MainVm.SelectedItem.Content;
            Assert.IsTrue(text.Contains(_replacementText));
            Assert.IsFalse(text.Contains(sought));
        }
    }
}
