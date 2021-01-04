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
    }
}
