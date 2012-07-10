using System;
using System.Linq;
using System.Timers;
using System.Windows.Threading;

namespace Galaxy.GoogleReader.WpfApplication.Engine
{
    public class ClientEngine
    {
        public event EventHandler<ClientEngineEventArgs> Update;

        public void InvokeUpdate(ClientEngineEventArgs e)
        {
            EventHandler<ClientEngineEventArgs> handler = Update;
            if (handler != null) handler(this, e);
        }

        private DispatcherTimer _timer;

        public ClientEngine()
        {
            _timer = new DispatcherTimer();
            _timer.Interval =TimeSpan.FromMilliseconds( 5 * 1000);
            _timer.Tick += new EventHandler(_timer_Elapsed);
        }

        void _timer_Elapsed(object sender, EventArgs eventArgs)
        {
            try
            {
                var dataContext = new GoogleReaderDataContext();
                var feeds = from f in dataContext.Feeds select f;
                var list = feeds.ToList();
                var args = new ClientEngineEventArgs
                               {
                                   UpdateItems = list
                               };
                InvokeUpdate(args);
            }
            catch (Exception)
            {
                //todo
                //throw;
            }
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }

}