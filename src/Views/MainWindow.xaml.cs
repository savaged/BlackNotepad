using Savaged.BlackNotepad.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Savaged.BlackNotepad.Views
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel = DataContext as MainViewModel;
            _viewModel.GoToRequested += OnGoToRequested;
        }

        private void OnGoToRequested(int position)
        {
            if (position > 0)
            {
                ContentText.CaretIndex = position;
            }
        }

        private void OnContentTextSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.SelectedText = ContentText.SelectedText;

                var selectionStart = ContentText.SelectionStart;
                var line = ContentText.GetLineIndexFromCharacterIndex(selectionStart);
                var column = selectionStart - 
                    ContentText.GetCharacterIndexFromLineIndex(line);
                _viewModel.CaretLine = line;
                _viewModel.CaretColumn = column;
                _viewModel.IndexOfCaret = selectionStart;
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (_viewModel != null)
            {
                var result = _viewModel.OnClosing();
                if (!result)
                {
                    e.Cancel = true;
                }
                _viewModel.GoToRequested -= OnGoToRequested;
            }
        }

        private void OnContentTextPreviewDragOver(object sender, DragEventArgs e)
        {
            if (_viewModel != null && _viewModel.CanExecuteDragDrop
                && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void OnContentTextPreviewDrop(object sender, DragEventArgs e)
        {
            if (_viewModel != null && _viewModel.CanExecuteDragDrop)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var fileLocation = (string[])e.Data.GetData(DataFormats.FileDrop);
                    _viewModel.New(fileLocation[0]);
                    e.Handled = true;
                    return;
                }
            }
            e.Handled = false;
        }

        private void OnUndoMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentText.Undo(); 
        }

        private void OnCutMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentText.Cut();
        }

        private void OnCopyMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentText.Copy();
        }

        private void OnPasteMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentText.Paste();
        }

        private void OnSelectAllMenuItemClick(object sender, RoutedEventArgs e)
        {
            ContentText.SelectAll();
        }
    }
}
