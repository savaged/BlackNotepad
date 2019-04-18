using System.Windows;
using System.Windows.Controls;

namespace Savaged.BlackNotepad.Views.Controls
{
    public partial class CancelButtonControl : UserControl
    {
        public CancelButtonControl()
        {
            InitializeComponent();
        }

        protected void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).DialogResult = false;
        }
    }
}
