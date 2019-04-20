using System.Windows;
using System.Windows.Controls;

namespace Savaged.BlackNotepad.Views.Controls
{
    public partial class TextSoughtInputControl : UserControl
    {
        public TextSoughtInputControl()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            FindText.Focus();
        }
    }
}
