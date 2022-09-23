using System;

namespace TaskAPI.Lib.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }

        public DuplicateItemException(string message, Exception ex) : base(message, ex) { }
    }
}
