using Savaged.BlackNotepad.Lookups;
using Savaged.BlackNotepad.Models;
using System.IO;
using System.Text;

namespace Savaged.BlackNotepad.Services
{
    public class FileModelService : IFileModelService
    {
        private FileModel _fileModel;

        public FileModel Load(string location)
        {
            _fileModel = new FileModel
            {
                Location = location
            };
            // TODO make async
            ReadFile();

            _fileModel.IsDirty = false;

            return _fileModel;
        }

        public void Save(FileModel fileModel)
        {
            File.WriteAllText(fileModel.Location, fileModel.Content);
            _fileModel.IsDirty = false;
        }

        private void ReadFile()
        {
            if (string.IsNullOrEmpty(_fileModel.Location)
                || string.IsNullOrWhiteSpace(_fileModel.Location))
            {
                return;
            }
            var contentBuilder = new StringBuilder();
            var lineEnding = LineEndings._;
            using (var sr = new StreamReader(_fileModel.Location))
            {
                var p = 0;
                while (p != -1)
                {
                    var i = sr.Read();
                    var c = (char)i;
                    contentBuilder.Append(c);
                    p = sr.Peek();

                    if (lineEnding == LineEndings._)
                    {
                        if (i == '\r' && p == '\n')
                        {
                            lineEnding = LineEndings.CRLF;
                        }
                        else if (i == '\n' && p == -1)
                        {
                            lineEnding = LineEndings.LF;
                        }
                        else if (i == '\r' && p == -1)
                        {
                            lineEnding = LineEndings.CR;
                        }
                    }
                }
                sr.Close();
            }
            _fileModel.LineEnding = lineEnding;
            _fileModel.Content = contentBuilder.ToString();
        }
    }
}
