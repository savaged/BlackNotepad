using Savaged.BlackNotepad.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Savaged.BlackNotepad.Views
{
    public partial class FindDialog : Dialog
    {
        private FindDialogViewModel _viewModel;

        public FindDialog()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null
                && DataContext is FindDialogViewModel vm)
            {
                _viewModel = vm;
            }
        }

        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.RaiseFindNext();
        }
    }
}
