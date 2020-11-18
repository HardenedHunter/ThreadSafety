using System;
using System.Threading;
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable

namespace ThreadSafety
{
    public class Presenter
    {
        private readonly IView _view;

        private readonly Manager _manager;

        public Presenter(IView view)
        {
            _view = view;
            _view.Start += OnStart;
            _manager = new Manager();
            _manager.WriterEventHappened += _view.OnWrite;
            _manager.ReaderEventHappened += _view.OnRead;
            ContextProvider.GetInstance().Context = SynchronizationContext.Current; 
        }

        private void OnStart()
        {
            _manager.Start();
        }

        ~Presenter()
        {
            Environment.Exit(0);
        }
    }
}