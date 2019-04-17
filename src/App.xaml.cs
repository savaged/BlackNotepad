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
            SimpleIoc.Default
                .Register<IFontColourLookupService, FontColourLookupService>();
            SimpleIoc.Default
                .Register<IFontFamilyLookupService, FontFamilyLookupService>();
            SimpleIoc.Default
                .Register<IFontZoomLookupService, FontZoomLookupService>();

            SimpleIoc.Default.Register<IViewStateService, ViewStateService>();


            SimpleIoc.Default
                .Register<IDialogService, DialogService>();

            SimpleIoc.Default.Register<MainViewModel>();
            var mainVm = SimpleIoc.Default.GetInstance<MainViewModel>();

            SimpleIoc.Default.Register<GoToDialogViewModel>();

            var mainView = new MainWindow
            {
                DataContext = mainVm
            };
            mainView.Show();
        }
    }
}
