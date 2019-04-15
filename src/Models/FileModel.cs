using GalaSoft.MvvmLight;

namespace Savaged.BlackNotepad.Models
{
    public class FileModel : ObservableObject
    {
        private string _name;
        private string _content;
        private string _lineEnding;
        private string _previousContent;
        private int _position;
        private bool _isDirty;

        public FileModel()
        {
            _name = "Untitled";
            _previousContent = _content = string.Empty;
            _lineEnding = "Windows (CRLF)"; // TODO Set this properly
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

        public int Position
        {
            get => _position;
            set => Set(ref _position, value);
        }

        public string LineEnding
        {
            get => _lineEnding;
            set => Set(ref _lineEnding, value);
        }

        public bool HasContent => !string.IsNullOrEmpty(Content);

        public bool IsDirty
        {
            get => _isDirty;
            set => Set(ref _isDirty, value);
        }

        public void UndoLastChangeToContent()
        {
            Content = _previousContent;
        }
    }
}
