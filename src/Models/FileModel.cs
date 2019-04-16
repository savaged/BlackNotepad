using GalaSoft.MvvmLight;
using System.IO;
using System.Text;

namespace Savaged.BlackNotepad.Models
{
    public class FileModel : ObservableObject
    {
        private string _name;
        private string _location;
        private string _content;
        private string _lineEnding;
        private string _previousContent;
        private int _position;
        private bool _isDirty;

        public FileModel()
        {
            Name = "Untitled";
            _previousContent = Content = string.Empty;
            LineEnding = "Windows (CRLF)"; // TODO Set this properly
        }

        public FileModel(string location) 
            : this()
        {
            Location = location;
            ReadFile();
        }

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
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

        private void ReadFile()
        {
            var contentBuilder = new StringBuilder();
            var lineEnding = string.Empty;
            using (var sr = new StreamReader(Location))
            {
                var p = 0;
                while (p != -1)
                {
                    var i = sr.Read();
                    var c = (char)i;
                    contentBuilder.Append(c);
                    p = sr.Peek();

                    if (string.IsNullOrEmpty(lineEnding))
                    {
                        if (i == '\r' && p == '\n')
                        {
                            lineEnding = "CRLF";
                        }
                        else if (i == '\n' && p == -1)
                        {
                            lineEnding = "LF";
                        }
                        else if (i == '\r' && p == -1)
                        {
                            lineEnding = "CR";
                        }
                    }
                }
                sr.Close();
            }
            LineEnding = lineEnding;
            Content = contentBuilder.ToString();
        }
    }
}
