using Savaged.BlackNotepad.ViewModels;
using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class FindDialog : Dialog
    {
        public FindDialog()
        {
            InitializeComponent();
        }

        private void OnActionButtonClick(object sender, RoutedEventArgs e)
        {
            if (DataContext != null 
                && DataContext is FindDialogViewModel vm)
            {
                vm.RaiseFindNext();
            }
        }
    }
}
