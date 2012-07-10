using System;
using System.Linq;
using System.Text;
using System.Timers;
using Galaxy.GoogleReader.Client;
using Galaxy.GoogleReader.WpfApplication.Models;

namespace Galaxy.GoogleReader.WpfApplication.Engine
{
    public class GoogleReaderEngine : Subject
    {
        public event EventHandler<GoogleReaderEngineEventArgs> Update;

        public void InvokeUpdate(GoogleReaderEngineEventArgs e)
        {
            EventHandler<GoogleReaderEngineEventArgs> handler = Update;
            if (handler != null) handler(this, e);
        }

        public GoogleReaderEngine()
        {
            this.GoogleReaderClient = new GoogleReaderClient("lotosbin@gmail.com", "Chaos@2010");
            this.m_Timer = new Timer
            {
                Interval = 5 * 1000
            };
            this.m_Timer.Elapsed += new ElapsedEventHandler(m_Timer_Elapsed);
        }

        void m_Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var listAllJson = this.GoogleReaderClient.ListAllJson();
            try
            {
                var dataContext = new GoogleReaderDataContext();
                foreach (ListAllJsonItem item in listAllJson.Items)
                {
                    var feed = new Feed
                                   {
                                       GoogleReaderId = item.Id,
                                       Title = item.Title,
                                       PublishedTime = item.Published
                                   };
                    dataContext.Feeds.InsertOnSubmit(feed);
                }
                dataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                //todo
                //throw;
            }
            var args = new GoogleReaderEngineEventArgs();
            args.UpdateItems = listAllJson.Items;
            InvokeUpdate(args);
        }

        private Timer m_Timer;
        public GoogleReaderClient GoogleReaderClient { get; private set; }

        public void Start()
        {

            this.m_Timer.Start();
        }

        public void Stop()
        {
            this.m_Timer.Stop();
        }
    }
}
