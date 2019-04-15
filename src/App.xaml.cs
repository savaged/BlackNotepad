using GalaSoft.MvvmLight.Ioc;
using Savaged.BlackNotepad.Services;
using Savaged.BlackNotepad.ViewModels;
using Savaged.BlackNotepad.Views;
using System.Windows;

namespace Savaged.BlackNotepad
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IFileService, FileService>();
            SimpleIoc.Default.Register<IViewStateService, ViewStateService>();
            SimpleIoc.Default.Register<MainViewModel>();

            var mainView = new MainWindow
            {
                DataContext = SimpleIoc.Default.GetInstance<MainViewModel>()
            };
            mainView.Show();
        }
    }
}
