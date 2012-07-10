using System;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;
using System.Xml;

namespace GoogleReaderAPI
{
    public class Reader : IDisposable
    {
        private Reader(string sid, string source)
        {
            this.SID = sid;
            this.Source = source;
        }

        private string SID { get; set; }
        private string Source { get; set; }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        public static Reader CreateReader(string email, string password, string source)
        {
            const string authUrl = @"https://www.google.com/accounts/ClientLogin";

            // extract the sid
            string response = HttpClient.Post(authUrl, new
                                                           {
                                                               service = "reader",
                                                               _continue = "http://www.google.com/",
                                                               Email = email,
                                                               Passwd = password,
                                                               source
                                                           });

            string sid = new Regex(@"^SID=(?<sid>\S+)").Match(response).Result("${sid}");

            if (string.IsNullOrEmpty(sid))
            {
                throw new ArgumentException("Invalid SID");
            }

            return new Reader(sid, source);
        }

        private void AttachSIDCookie(HttpWebRequest request)
        {
            var cookie = new Cookie("SID", this.SID);
            cookie.Domain = ".google.com";
            if (request.CookieContainer == null)
            {
                request.CookieContainer = new CookieContainer();
            }
            request.CookieContainer.Add(cookie);
        }

        public string GetSubscriptions()
        {
            const string url = @"http://www.google.com/reader/api/0/subscription/list";
            HttpWebRequest request = HttpClient.CreateGetRequest(url, new
                                                                          {
                                                                              output = "xml",
                                                                              ck = DateTime.Now.ToString(),
                                                                              client = this.Source
                                                                          });

            //  attach the cookie ...
            this.AttachSIDCookie(request);

            using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        public string GetTags()
        {
            const string url = @"http://www.google.com/reader/api/0/tag/list";
            HttpWebRequest request = HttpClient.CreateGetRequest(url, new
                                                                          {
                                                                              output = "xml",
                                                                              ck = DateTime.Now.ToString(),
                                                                              client = this.Source
                                                                          });

            //  attach the cookie ...
            this.AttachSIDCookie(request);

            using (var sr = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }

        public SyndicationFeed GetFeed(string url, int topN)
        {
            string feedUrl = string.Format(@"http://www.google.com/reader/atom/feed/{0}", url);
            HttpWebRequest feedRequest = HttpClient.CreateGetRequest(feedUrl, new {n = topN});

            //  attach the cookie ...
            this.AttachSIDCookie(feedRequest);

            using (var sr = new StreamReader(feedRequest.GetResponse().GetResponseStream()))
            {
                return SyndicationFeed.Load(XmlReader.Create(sr, new XmlReaderSettings()));
            }
        }

        public SyndicationFeed StarredFeed(int topN)
        {
            return this.StateFeed(topN, "starred");
        }

        public SyndicationFeed ReadFeed(int topN)
        {
            return this.StateFeed(topN, "read");
        }

        public SyndicationFeed KeptUnreadFeed(int topN)
        {
            return this.StateFeed(topN, "kept-unread");
        }

        public SyndicationFeed FreshFeed(int topN)
        {
            return this.StateFeed(topN, "fresh");
        }

        public SyndicationFeed PublicFeed(int topN)
        {
            return this.StateFeed(topN, "broadcast");
        }

        public SyndicationFeed ReadingListFeed(int topN)
        {
            return this.StateFeed(topN, "reading-list");
        }

        private SyndicationFeed StateFeed(int topN, string state)
        {
            const string url = @"http://www.google.com/reader/atom/user/-/state/com.google/{0}";
            HttpWebRequest stateFeedRequest = HttpClient.CreateGetRequest(string.Format(url, state), new {n = topN});

            //  attach the cookie ...
            this.AttachSIDCookie(stateFeedRequest);

            using (var sr = new StreamReader(stateFeedRequest.GetResponse().GetResponseStream()))
            {
                return SyndicationFeed.Load(XmlReader.Create(sr, new XmlReaderSettings()));
            }
        }
    }
}