using System.Collections.Generic;
using System.Threading;

namespace ThreadSafety
{
    public class Buffer
    {
        public int Id { get; }

        private readonly int _capacity;

        private readonly Stack<string> _data;

        public Buffer(int id, int capacity)
        {
            Id = id;
            _capacity = capacity;
            _data = new Stack<string>();
        }

        public void WriteData(string item)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_data, ref lockWasTaken);
                if (_data.Count == _capacity)
                    throw new BufferOverflowException();
                _data.Push(item);
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_data);
            }
        }

        public string ReadData()
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_data, ref lockWasTaken);
                if (_data.Count == 0)
                    throw new EmptyBufferException();
                return _data.Pop();
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_data);
            }
        }
    }
}