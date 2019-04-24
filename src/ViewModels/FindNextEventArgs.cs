using System;

namespace Savaged.BlackNotepad.ViewModels
{
    public class FindNextEventArgs : EventArgs
    {
        public FindNextEventArgs(
            bool isFindWrapAround, 
            bool isFindMatchCase)
        {
            IsFindWrapAround = isFindWrapAround;
            IsFindMatchCase = isFindMatchCase;
        }

        public bool IsFindWrapAround { get; }

        public bool IsFindMatchCase { get; }
    }
}
