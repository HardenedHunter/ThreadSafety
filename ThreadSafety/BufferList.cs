using System.Collections.Generic;
using System.Threading;

namespace ThreadSafety
{
    public class BufferList
    {
        private readonly List<Buffer> _buffers = new List<Buffer>();

        private int _idCounter;

        public int Count
        {
            get
            {
                bool lockWasTaken = false;
                try
                {
                    Monitor.Enter(_buffers, ref lockWasTaken);
                    return _buffers.Count;
                }
                finally
                {
                    if (lockWasTaken) Monitor.Exit(_buffers);
                }
            }
        }

        public void WriteData(int bufferIndex, string data)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_buffers, ref lockWasTaken);
                _buffers[bufferIndex].WriteData(data);
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_buffers);
            }
        }

        public Buffer AddBuffer(int capacity = 5)
        {
            var buffer = new Buffer(++_idCounter, capacity);
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_buffers, ref lockWasTaken);
                _buffers.Add(buffer);
                return buffer;

            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_buffers);
            }
        }

        public void RemoveBuffer(int bufferId)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_buffers, ref lockWasTaken);
                _buffers.RemoveAll(buffer => buffer.Id == bufferId);
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_buffers);
            }
        }

        public int GetId(int bufferIndex)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_buffers, ref lockWasTaken);
                return _buffers[bufferIndex].Id;
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_buffers);
            }
        }

        public int GetIndexById(int bufferId)
        {
            bool lockWasTaken = false;
            try
            {
                Monitor.Enter(_buffers, ref lockWasTaken);
                return _buffers.FindIndex(b => b.Id == bufferId);
            }
            finally
            {
                if (lockWasTaken) Monitor.Exit(_buffers);
            }
        }
    }
}