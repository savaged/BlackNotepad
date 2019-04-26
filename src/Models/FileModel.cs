using GalaSoft.MvvmLight;
using Savaged.BlackNotepad.Lookups;
using System.IO;
using System.Text;

namespace Savaged.BlackNotepad.Models
{
    public class FileModel : ObservableObject
    {
        private const string _NEW = "Untitled";

        private string _name;
        private string _location;
        private string _content;
        private LineEndings _lineEnding;
        private string _previousContent;
        private int _position;
        private bool _isDirty;

        public FileModel()
        {
            Name = _NEW;
            _previousContent = Content = string.Empty;
            IsDirty = false;
            LineEnding = LineEndings.CRLF;
        }

        public bool IsNew => Name == _NEW;

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    Name = _NEW;
                }
                return _name;
            }
            set
            {
                Set(ref _name, value);
                RaisePropertyChanged(nameof(IsNew));
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                Set(ref _location, value);
                Name = Path.GetFileName(value);
            }
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
                    if (_previousContent != _content)
                    {
                        IsDirty = true;
                    }
                    if (string.IsNullOrEmpty(_content))
                    {
                        IsDirty = false;
                    }
                }
            }
        }

        public int Position
        {
            get => _position;
            set => Set(ref _position, value);
        }

        public LineEndings LineEnding
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
    }
}
