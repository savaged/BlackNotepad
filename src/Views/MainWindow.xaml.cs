using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMenuExitClick(object sender, RoutedEventArgs e)
        {
            // TODO check with ViewModel for unsaved work
            Application.Current.Shutdown();
        }
    }
}
