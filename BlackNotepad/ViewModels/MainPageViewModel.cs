using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Savaged.BlackNotepad.Models;

namespace Savaged.BlackNotepad.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private FileModel _selectedItem;

        public MainPageViewModel()
        {
            _selectedItem = new FileModel();

            NewCmd = new RelayCommand(OnNew, () => CanExecute);
            OpenCmd = new RelayCommand(OnOpen, () => CanExecute);
            SaveCmd = new RelayCommand(OnSave, () => CanExecute);
            SaveAsCmd = new RelayCommand(OnSaveAs, () => CanExecute);

            ZoomCmd = new RelayCommand(OnZoom, () => CanExecute);
            StatusBarCmd = new RelayCommand(OnStatusBar, () => CanExecute);
        }

        public FileModel SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public RelayCommand NewCmd { get; }

        public RelayCommand OpenCmd { get; }

        public RelayCommand SaveCmd { get; }

        public RelayCommand SaveAsCmd { get; }

        public RelayCommand ZoomCmd { get; }

        public RelayCommand StatusBarCmd { get; }

        public bool CanExecute => true; // TODO make this useful

        private void OnNew()
        {

        }

        private void OnOpen()
        {

        }

        private void OnSave()
        {

        }

        private void OnSaveAs()
        {

        }

        private void OnZoom()
        {

        }

        private void OnStatusBar()
        {

        }
    }
}
