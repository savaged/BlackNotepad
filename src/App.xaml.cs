using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.Views;
using System.Windows;

namespace Savaged.BlackNotepad
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            var mainView = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            mainView.Show();
        }
    }
}
