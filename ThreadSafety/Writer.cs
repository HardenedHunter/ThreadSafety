using System;
using System.Threading;

namespace ThreadSafety
{
    public class Writer
    {
        private readonly BufferList _bufferList;

        private const int EmptyBuffersWaitingTime = 10;

        public event Action<string> WriterEvent;

        private readonly Random _random;

        public Writer(BufferList bufferList)
        {
            _bufferList = bufferList;
            _random = new Random();
        }

        public void Start()
        {
            var thread = new Thread(Process);
            thread.Start();
        }

        private void Process()
        {
            var iterationsWithEmptyBuffers = 0;
            bool shouldRepeat = false;
            int bufferId = -1;
            while (iterationsWithEmptyBuffers < EmptyBuffersWaitingTime)
            {
                bool lockWasTaken = false;
                try
                {
                    Monitor.Enter(_bufferList, ref lockWasTaken);
                    if (shouldRepeat)
                    {
                        int index = _bufferList.GetIndexById(bufferId);
                        if (index == -1)
                            InvokeEvent("Повторить попытку не удалось, буфер был удалён");
                        else
                        {
                            _bufferList.WriteData(index, DateTime.Now.ToLongTimeString());
                            InvokeEvent($"Писатель добавил элемент в буфер №{bufferId}");
                        }
                        shouldRepeat = false;
                    }
                    else
                    {
                        int buffersCount = _bufferList.Count;
                        if (buffersCount == 0)
                        {
                            iterationsWithEmptyBuffers++;
                            InvokeEvent("Список буферов пуст");
                        }
                        else
                        {
                            iterationsWithEmptyBuffers = 0;
                            int index = _random.Next(0, buffersCount - 1);
                            bufferId = _bufferList.GetId(index);
                            _bufferList.WriteData(index, DateTime.Now.ToLongTimeString());
                            shouldRepeat = false;
                            InvokeEvent($"Писатель добавил элемент в буфер №{bufferId}");
                        }
                    }
                }
                catch (BufferOverflowException)
                {
                    InvokeEvent($"Писатель не смог добавить элемент в буфер №{bufferId}");
                    shouldRepeat = true;
                }
                finally
                {
                    if (lockWasTaken) Monitor.Exit(_bufferList);
                }

                Thread.Sleep(_random.Next(500));
            }

            InvokeEvent("Писатель завершил работу");
        }

        private void InvokeEvent(string message)
        {
            ContextProvider.Send(msg => WriterEvent?.Invoke(msg as string), message);
        }
    }
}