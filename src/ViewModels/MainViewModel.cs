using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Savaged.BlackNotepad.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Savaged.BlackNotepad.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IList<string> _busyRegister;
        private FileModel _selectedItem;
        private string _selectedText;
        private string _findText;

        public MainViewModel()
        {
            _busyRegister = new List<string>();
            ViewState = new ViewStateModel();
            _selectedItem = new FileModel();

            NewCmd = new RelayCommand(OnNew, () => CanExecute);
            OpenCmd = new RelayCommand(OnOpen, () => CanExecute);
            SaveCmd = new RelayCommand(OnSave, () => CanExecute);
            SaveAsCmd = new RelayCommand(OnSaveAs, () => CanExecute);
            ExitCmd = new RelayCommand(OnExit, () => CanExecuteExit);
            UndoCmd = new RelayCommand(OnUndo, () => CanExecuteUndo);
            CutCmd = new RelayCommand(OnCut, () => CanExecuteCutOrCopy);
            CopyCmd = new RelayCommand(OnCopy, () => CanExecuteCutOrCopy);
            PasteCmd = new RelayCommand(OnPaste, () => CanExecutePaste);
            FindCmd = new RelayCommand(OnFind, () => CanExecute);
            FindNextCmd = new RelayCommand(OnFindNext, () => CanExecuteFindNext);
            ReplaceCmd = new RelayCommand(OnReplace, () => CanExecuteReplace);
            GoToCmd = new RelayCommand(OnGoTo, () => CanExecute);
            SelectAllCmd = new RelayCommand(OnSelectAll, () => CanExecuteSelectAll);
            TimeDateCmd = new RelayCommand(OnTimeDate, () => CanExecute);
            WordWrapCmd = new RelayCommand(OnWordWrap, () => CanExecute);
            ZoomInCmd = new RelayCommand(OnZoomIn, () => CanExecute);
            ZoomOutCmd = new RelayCommand(OnZoomOut, () => CanExecute);
            RestoreCmd = new RelayCommand(OnRestore, () => CanExecute);
            StatusBarCmd = new RelayCommand(OnStatusBar, () => CanExecute);
            HelpCmd = new RelayCommand(OnHelp, () => CanExecute);
            AboutCmd = new RelayCommand(OnAbout, () => CanExecute);
        }

        public string Title => $"{SelectedItem?.Name} - Black Notepad";

        public bool IsBusy => _busyRegister.Count > 0;

        public ViewStateModel ViewState { get; }

        public FileModel SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public string FindText
        {
            get => _findText;
            set => Set(ref _findText, value);
        }

        public string SelectedText
        {
            get => _selectedText;
            set => Set(ref _selectedText, value);
        }

        public RelayCommand NewCmd { get; }
        public RelayCommand OpenCmd { get; }
        public RelayCommand SaveCmd { get; }
        public RelayCommand SaveAsCmd { get; }
        public RelayCommand ExitCmd { get; }
        public RelayCommand UndoCmd { get; }
        public RelayCommand CutCmd { get; }
        public RelayCommand CopyCmd { get; }
        public RelayCommand PasteCmd { get; }
        public RelayCommand FindCmd { get; }
        public RelayCommand FindNextCmd { get; }
        public RelayCommand ReplaceCmd { get; }
        public RelayCommand GoToCmd { get; }
        public RelayCommand SelectAllCmd { get; }
        public RelayCommand TimeDateCmd { get; }
        public RelayCommand WordWrapCmd { get; }
        public RelayCommand ZoomInCmd { get; }
        public RelayCommand ZoomOutCmd { get; }
        public RelayCommand RestoreCmd { get; }
        public RelayCommand StatusBarCmd { get; }
        public RelayCommand HelpCmd { get; }
        public RelayCommand AboutCmd { get; }

        public bool CanExecute => !IsBusy;

        public bool CanExecuteExit => CanExecute && 
            !SelectedItem.IsDirty;

        public bool CanExecuteSave => CanExecute &&
            SelectedItem.IsDirty;

        public bool CanExecuteUndo => CanExecute &&
            SelectedItem.IsDirty;

        public bool CanExecuteCutOrCopy => CanExecute &&
            !string.IsNullOrEmpty(SelectedText);

        public bool CanExecutePaste => CanExecute && 
            Clipboard.ContainsText();

        public bool CanExecuteFindNext => CanExecute &&
            !string.IsNullOrEmpty(FindText);

        public bool CanExecuteReplace => CanExecute;

        public bool CanExecuteGoTo => CanExecute &&
            SelectedItem.HasContent && !ViewState.IsWrapped;

        public bool CanExecuteSelectAll => CanExecute &&
            SelectedItem.HasContent;

        private void StartLongOperation([CallerMemberName]string caller = "")
        {
            _busyRegister.Add(caller);
        }

        private void EndLongOpertation([CallerMemberName]string caller = "")
        {
            _busyRegister.Remove(caller);
        }

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

        private void OnExit()
        {

            Application.Current.Shutdown();
        }

        private void OnUndo()
        {

        }

        private void OnCut()
        {

        }

        private void OnCopy()
        {

        }

        private void OnPaste()
        {

        }

        private void OnFind()
        {

        }

        private void OnFindNext()
        {

        }

        private void OnReplace()
        {

        }

        private void OnGoTo()
        {

        }

        private void OnSelectAll()
        {

        }

        private void OnTimeDate()
        {

        }

        private void OnWordWrap()
        {

        }

        private void OnZoomIn()
        {

        }

        private void OnZoomOut()
        {

        }

        private void OnRestore()
        {

        }

        private void OnStatusBar()
        {
            ViewState.IsStatusBarVisible = !ViewState.IsStatusBarVisible;
        }

        private void OnHelp()
        {
            StartLongOperation();

            Process.Start(
                "https://www.bing.com/search?q=get+help+with+notepad+in+windows+10");

            EndLongOpertation();
        }

        private void OnAbout()
        {

        }
    }
}
