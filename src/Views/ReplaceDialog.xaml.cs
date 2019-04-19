using Savaged.BlackNotepad.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class ReplaceDialog : Dialog
    {
        private ReplaceDialogViewModel _viewModel;

        public ReplaceDialog()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null
                && DataContext is ReplaceDialogViewModel vm)
            {
                _viewModel = vm;
            }
        }

        private void OnFindButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.RaiseFindNext();
        }

        private void OnReplaceButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.RaiseReplace();
        }

        private void OnReplaceAllButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.RaiseReplaceAll();
        }

        protected override void OnCloseCommandExecuted(
            object sender, ExecutedRoutedEventArgs e)
        {
            _viewModel?.ResetFilters();
            base.OnCloseCommandExecuted(sender, e);
        }
    }
}
