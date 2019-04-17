using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using Savaged.BlackNotepad.Models;
using Savaged.BlackNotepad.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Savaged.BlackNotepad.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IList<string> _busyRegister;
        private readonly OpenFileDialog _openFileDialog;
        private readonly SaveFileDialog _saveFileDialog;
        private readonly IViewStateService _viewStateService;
        private FileModel _selectedItem;
        private string _selectedText;
        private string _findText;

        public MainViewModel(IViewStateService viewStateService)
        {
            const string filter = "Text Documents|*.txt";
            _openFileDialog = new OpenFileDialog
            {
                Filter = filter
            };
            _saveFileDialog = new SaveFileDialog
            {
                Filter = filter
            };
            _viewStateService = viewStateService;
            ViewState = _viewStateService.Open();

            FontColours = new List<FontColour>
            {
                new FontColour("LightGreen", "Light Green"),
                new FontColour("White", "White")
            };
            ViewState.SelectedFontColour = FontColours.First();

            _busyRegister = new List<string>();
            _selectedItem = new FileModel();

            NewCmd = new RelayCommand(OnNew, () => CanExecute);
            OpenCmd = new RelayCommand(OnOpen, () => CanExecuteOpen);
            SaveCmd = new RelayCommand(OnSave, () => CanExecute);
            SaveAsCmd = new RelayCommand(OnSaveAs, () => CanExecute);
            ExitCmd = new RelayCommand(OnExit, () => CanExecute);
            FindCmd = new RelayCommand(OnFind, () => CanExecute);
            FindNextCmd = new RelayCommand(OnFindNext, () => CanExecuteFindNext);
            ReplaceCmd = new RelayCommand(OnReplace, () => CanExecuteReplace);
            GoToCmd = new RelayCommand(OnGoTo, () => CanExecute);
            TimeDateCmd = new RelayCommand(OnTimeDate, () => CanExecute);
            WordWrapCmd = new RelayCommand(OnWordWrap, () => CanExecute);
            FontCmd = new RelayCommand(OnFont, () => CanExecuteFont);
            ZoomInCmd = new RelayCommand(OnZoomIn, () => CanExecute);
            ZoomOutCmd = new RelayCommand(OnZoomOut, () => CanExecute);
            RestoreCmd = new RelayCommand(OnRestore, () => CanExecute);
            StatusBarCmd = new RelayCommand(OnStatusBar, () => CanExecute);
            HelpCmd = new RelayCommand(OnHelp, () => CanExecute);
            AboutCmd = new RelayCommand(OnAbout, () => CanExecute);
            FontColourCmd = new RelayCommand<FontColour>(OnFontColour, (b) => CanExecute);

            SelectedItem.PropertyChanged += OnSelectedItemPropertyChanged;
        }

        public override void Cleanup()
        {
            SelectedItem.PropertyChanged -= OnSelectedItemPropertyChanged;
            base.Cleanup();
        }

        public bool OnClosing()
        {
            var hasChangesToSave = SaveChangesConfirmation();
            if (hasChangesToSave)
            {
                Save();
            }
            _viewStateService.Save(ViewState);
            return true;
        }

        public void New(string location = null)
        {
            var hasChangesToSave = SaveChangesConfirmation();
            if (hasChangesToSave)
            {
                Save();
            }
            SelectedItem = new FileModel(location);
        }

        public string Title => $"{SelectedItem?.Name} - Black Notepad";

        public bool IsBusy => _busyRegister.Count > 0;

        public ViewStateModel ViewState { get; }

        public IList<FontColour> FontColours { get; }

        public FileModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                Set(ref _selectedItem, value);
                RaisePropertyChanged(nameof(Title));
            }
        }

        public string FindText
        {
            get => _findText;
            set => Set(ref _findText, value);
        }

        public string SelectedText
        {
            get => _selectedText;
            set
            {
                Set(ref _selectedText, value);
                RaisePropertyChanged(nameof(IsCutOrCopyEnabled));
                RaisePropertyChanged(nameof(IsPasteEnabled));
            }
        }

        public RelayCommand NewCmd { get; }
        public RelayCommand OpenCmd { get; }
        public RelayCommand SaveCmd { get; }
        public RelayCommand SaveAsCmd { get; }
        public RelayCommand ExitCmd { get; }
        public RelayCommand FindCmd { get; }
        public RelayCommand FindNextCmd { get; }
        public RelayCommand ReplaceCmd { get; }
        public RelayCommand GoToCmd { get; }
        public RelayCommand TimeDateCmd { get; }
        public RelayCommand WordWrapCmd { get; }
        public RelayCommand FontCmd { get; }
        public RelayCommand ZoomInCmd { get; }
        public RelayCommand ZoomOutCmd { get; }
        public RelayCommand RestoreCmd { get; }
        public RelayCommand StatusBarCmd { get; }
        public RelayCommand HelpCmd { get; }
        public RelayCommand AboutCmd { get; }
        public RelayCommand<FontColour> FontColourCmd { get; }

        public bool CanExecute => !IsBusy;

        public bool CanExecuteOpen => CanExecute &&
            !SelectedItem.IsDirty;

        public bool CanExecuteSave => CanExecute &&
            SelectedItem.IsDirty;

        public bool CanExecuteFindNext => CanExecute &&
            !string.IsNullOrEmpty(FindText);

        public bool CanExecuteReplace => CanExecute;

        public bool CanExecuteGoTo => CanExecute &&
            SelectedItem.HasContent && !ViewState.IsWrapped;

        public bool CanExecuteFont => false; // TODO see OnFont

        public bool CanExecuteDragDrop => CanExecute &&
            !SelectedItem.IsDirty;


        public bool IsUndoEnabled => !IsBusy &&
            SelectedItem.IsDirty;

        public bool IsCutOrCopyEnabled => !IsBusy &&
            !string.IsNullOrEmpty(SelectedText);

        public bool IsPasteEnabled => !IsBusy &&
            Clipboard.ContainsText();

        public bool IsSelectAllEnabled => !IsBusy &&
            SelectedItem.HasContent;


        private void StartLongOperation([CallerMemberName]string caller = "")
        {
            _busyRegister.Add(caller);
            RaisePropertyChanged(nameof(IsBusy));
        }

        private void EndLongOpertation([CallerMemberName]string caller = "")
        {
            _busyRegister.Remove(caller);
            RaisePropertyChanged(nameof(IsBusy));
        }

        private void OnNew()
        {
            New();
        }

        private void OnOpen()
        {
            var result = _openFileDialog.ShowDialog();
            if (result == true)
            {
                StartLongOperation();

                SelectedItem = new FileModel(_openFileDialog.FileName);

                EndLongOpertation();
            }
        }

        private void OnSave()
        {
            Save();
        }
        private void Save()
        {
            if (!SelectedItem.IsNew)
            {
                StartLongOperation();

                File.WriteAllText(SelectedItem.Location, SelectedItem.Content);

                SelectedItem.IsDirty = false;

                EndLongOpertation();
            }
            else
            {
                SaveAs();
            }
        }

        private void OnSaveAs()
        {
            SaveAs();
        }
        private void SaveAs()
        {
            var result = _saveFileDialog.ShowDialog();
            if (result == true)
            {
                SelectedItem.Location = _saveFileDialog.FileName;
                OnSave();
            }
        }

        private void OnExit()
        {
            OnClosing();
            Application.Current.Shutdown();
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

        private void OnTimeDate()
        {

        }

        private void OnWordWrap()
        {
            ViewState.IsWrapped = !ViewState.IsWrapped;
        }

        private void OnFont()
        {
            // TODO use windows forms fontdialog
        }

        private void OnZoomIn()
        {
            ViewState.ZoomIn();
        }

        private void OnZoomOut()
        {
            ViewState.ZoomOut();
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
                "https://www.microsoft.com/en-gb/search?q=BlackNotepad");

            EndLongOpertation();
        }

        private void OnAbout()
        {
            MessageBox.Show(
                "A black 'version' of the classic Microsoft Windows Notepad application", 
                "About");
        }

        private void OnFontColour(FontColour selected)
        {
            ViewState.SelectedFontColour = selected;
            foreach (var fontColour in FontColours)
            {
                if (fontColour.Name != ViewState.SelectedFontColour.Name)
                {
                    fontColour.IsSelected = false;
                }
            }
            RaisePropertyChanged(nameof(FontColours));
        }

        private bool SaveChangesConfirmation()
        {
            var value = false;
            if (SelectedItem.IsDirty)
            {
                var result = MessageBox.Show(
                    $"Do you want to save changes to {SelectedItem.Name}?",
                    "Black Notepad",
                    MessageBoxButton.YesNoCancel);
                value = result == MessageBoxResult.Yes;
            }
            return value;
        }

        private void OnSelectedItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SelectedItem.Content):
                    RaisePropertyChanged(nameof(IsUndoEnabled));
                    RaisePropertyChanged(nameof(IsSelectAllEnabled));
                    break;
            }
        }
    }
}
