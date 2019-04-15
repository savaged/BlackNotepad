using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class FileModel : ObservableObject
    {
        private string _name;
        private string _content;
        private string _previousContent;

        public FileModel()
        {
            _name = "Untitled";
            _previousContent = _content = string.Empty;
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Content
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _previousContent = _content;
                    Set(ref _content, value);
                }
            }
        }

        public void UndoLastChangeToContent()
        {
            Content = _previousContent;
        }
    }
}
