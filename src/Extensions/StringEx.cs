using Savaged.BlackNotepad.Lookups;

namespace Savaged.BlackNotepad.Extensions
{
    public static class StringEx
    {
        public static int LineOfIndexOrDefault(
            this string self, int index, LineEndings lineEnding)
        {
            var lineEndingChar = '\r';
            if (lineEnding == LineEndings.LF)
            {
                lineEndingChar = '\n';
            }
            var linesCounted = 0;
            var value = 1;
            for (int i = 0; i < self.Length; i++)
            {
                if (self[i] == lineEndingChar
                    || i == self.Length - 1)
                {
                    linesCounted++;
                }
                if (index == i)
                {
                    value = linesCounted;
                    break;
                }
            }
            return value;
        }
    }
}
