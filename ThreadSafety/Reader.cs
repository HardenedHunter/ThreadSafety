using System;
using System.Threading;

namespace ThreadSafety
{
    public class Reader
    {
        private readonly Buffer _buffer;

        private readonly int _lifespan;

        public event Action<string> ReaderEvent;
        public event Action<Buffer> ReaderFinished;

        public Reader(Buffer buffer, int lifespan)
        {
            _buffer = buffer;
            _lifespan = lifespan;
        }

        public void Start()
        {
            var thread = new Thread(Process) {IsBackground = true};
            thread.Start();
        }

        private void Process()
        {
            var processedData = 0;
            var random = new Random();
            while (processedData != _lifespan)
            {
                try
                {
                    var data = _buffer.ReadData();
                    processedData++;
                    InvokeEvent($"Читатель {_buffer.Id} забрал данные: {data}");
                }
                catch (EmptyBufferException)
                {
                    InvokeEvent($"Читатель {_buffer.Id} не смог прочитать из пустого буфера");
                }

                Thread.Sleep(random.Next(2000));
            }

            InvokeFinished();
        }

        private void InvokeEvent(string message)
        {
            ContextProvider.Send(msg => ReaderEvent?.Invoke(msg as string), message);
        }

        private void InvokeFinished()
        {
            ContextProvider.Send(buffer => ReaderFinished?.Invoke(buffer as Buffer), _buffer);
            InvokeEvent($"Читатель {_buffer.Id} завершил свою работу.");
        }
    }
}