using Savaged.BlackNotepad.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Drawing;

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
        }

        private void OnContentTextSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.SelectedText = ContentText.SelectedText;
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.OnClosing();
            }
        }
    }
}
