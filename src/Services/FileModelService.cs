using Savaged.BlackNotepad.Lookups;
using Savaged.BlackNotepad.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Savaged.BlackNotepad.Services
{
    public class FileModelService : IFileModelService
    {
        public FileModel New()
        {
            return new FileModel();
        }

        public async Task<FileModel> LoadAsync(string location)
        {
            var fileModel = new FileModel
            {
                Location = location
            };
            await Task.Run(() => ReadFile(fileModel));
            
            return fileModel;
        }

        public async Task SaveAsync(FileModel fileModel)
        {
            await Task.Run(() => SaveFile(fileModel));
        }

        private void SaveFile(FileModel fileModel)
        {
            File.WriteAllText(fileModel.Location, fileModel.Content);
            fileModel.IsDirty = false;
        }

        private void ReadFile(FileModel fileModel)
        {
            if (string.IsNullOrEmpty(fileModel.Location)
                || string.IsNullOrWhiteSpace(fileModel.Location))
            {
                return;
            }
            var contentBuilder = new StringBuilder();
            var lineEnding = LineEndings._;
            using (var sr = new StreamReader(fileModel.Location))
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
            fileModel.LineEnding = lineEnding;
            fileModel.Content = contentBuilder.ToString();
            fileModel.IsDirty = false;
        }
    }
}
