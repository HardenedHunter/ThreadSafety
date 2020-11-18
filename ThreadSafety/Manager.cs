using System;
using System.Threading;

namespace ThreadSafety
{
    public class Manager
    {
        private readonly Writer _writer;
        private readonly BufferList _bufferList;

        public event Action<string> ReaderEventHappened;
        public event Action<string> WriterEventHappened;

        public Manager()
        {
            _bufferList = new BufferList();
            _writer = new Writer(_bufferList);
            _writer.WriterEvent += OnWriterEvent;
        }

        public void Start()
        {
            var thread = new Thread(Manage) { IsBackground = true };
            thread.Start();
            _writer.Start();
        }

        public void Manage()
        {
            const int bufferCapacity = 5;
            const int readerLimit = 5;
            for (var i = 0; i < readerLimit; i++)
            {
                Thread.Sleep(1000);
                var buffer = _bufferList.AddBuffer();
                var reader = new Reader(buffer, bufferCapacity);
                reader.ReaderEvent += OnReaderEvent;
                reader.ReaderFinished += OnReaderFinished;
                reader.Start();
            }
        }

        private void OnReaderEvent(string message)
        {
            ReaderEventHappened?.Invoke(message);
        }

        private void OnReaderFinished(Buffer buffer)
        {
            _bufferList.RemoveBuffer(buffer.Id);
        }

        private void OnWriterEvent(string message)
        {
            WriterEventHappened?.Invoke(message);
        }
    }
}