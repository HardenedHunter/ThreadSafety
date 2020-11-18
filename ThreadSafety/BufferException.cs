using System;

namespace ThreadSafety
{
    public class BufferException : Exception
    {
        public BufferException(string message = "") : base(message)
        {
        }
    }

    public class BufferOverflowException : BufferException
    {
        public BufferOverflowException(string message = "") : base(message)
        {
        }
    }

    public class EmptyBufferException : BufferException
    {
        public EmptyBufferException(string message = "") : base(message)
        {
        }
    }
}