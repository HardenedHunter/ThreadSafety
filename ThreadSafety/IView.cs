using System;

namespace ThreadSafety
{
    public interface IView
    {
        void OnWrite(string message);
        void OnRead(string message);
        event Action Start;
    }
}