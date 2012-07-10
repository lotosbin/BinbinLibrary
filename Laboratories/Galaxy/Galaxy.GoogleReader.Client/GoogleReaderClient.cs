using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Galaxy.GoogleReader.Client.Models.Tag;
using Galaxy.GoogleReader.Client.Models.UserInfo;
using Galaxy.GoogleReader.WpfApplication.Models;
using Galaxy.GoogleReader.WpfApplication.Models.UnreadCount;

namespace Galaxy.GoogleReader.Client
{
    public class GoogleReaderClient
    {
        public event EventHandler<GoogleReaderClientEventArgs> Get;

        public void InvokeGet(GoogleReaderClientEventArgs e)
        {
            EventHandler<GoogleReaderClientEventArgs> handler = Get;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<GoogleReaderClientEventArgs> Post;

        public void InvokePost(GoogleReaderClientEventArgs e)
        {
            EventHandler<GoogleReaderClientEventArgs> handler = Post;
            if (handler != null) handler(this, e);
        }

        #region New region

        public GoogleReaderClient(string username, string password)
        {
            this.Username = username;
            this.Password = password;

            bool connectSuccess = this.Connect();
            if (!connectSuccess)
            {
                //todo log
            }
        }

        #endregion

        #region New region

        public string Password { get; private set; }
        public string Username { get; private set; }
        public Cookie Cookie { get; private set; }
        public string Sid { get; private set; }
        public string Token { get; private set; }

        #endregion

        #region New region

        private bool Connect()
        {
            this.GetToken();
            return this.Token != null;
        }

        #endregion

        #region New region

        private HttpWebResponse HttpGet(string requestUrl, string getArgs)
        {
            string url = string.Format("{0}?{1}", requestUrl, getArgs);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(this.Cookie);

            try
            {
                GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
                                                            {
                                                                Url = url
                                                            };
                InvokeGet(eventArgs);
                return (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                // handle error
                return null;
            }
        }

        private HttpWebResponse HttpPost(string requestUrl, string postArgs)
        {
            byte[] buffer = Encoding.GetEncoding(1252).GetBytes(postArgs);

            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "POST";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(this.Cookie);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = buffer.Length;

            Stream postData = request.GetRequestStream();

            postData.Write(buffer, 0, buffer.Length);
            postData.Close();

            try
            {
                GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
                {
                    Url = requestUrl
                };
                InvokePost(eventArgs);
                return (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                //handle error
                return null;
            }
        }

        #endregion

        #region New region

        private void GetToken()
        {
            this.GetSid();
            this.Cookie = new Cookie("SID", this.Sid, "/", ".google.com");

            const string url = "http://www.google.com/reader/api/0/token";

            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.CookieContainer = new CookieContainer();
            req.CookieContainer.Add(this.Cookie);

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokeGet(eventArgs);
            var response = (HttpWebResponse)req.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                var r = new StreamReader(stream);
                this.Token = r.ReadToEnd();
            }
        }

        private void GetSid()
        {
            string requestUrl = string.Format
                ("https://www.google.com/accounts/ClientLogin?service=reader&Email={0}&Passwd={1}",
                 this.Username, this.Password);
            var req = (HttpWebRequest)WebRequest.Create(requestUrl);
            req.Method = "GET";

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = requestUrl
            };
            InvokeGet(eventArgs);
            var response = (HttpWebResponse)req.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                var r = new StreamReader(stream);
                string resp = r.ReadToEnd();

                int indexSid = resp.IndexOf("SID=") + 4;
                int indexLsid = resp.IndexOf("LSID=");
                this.Sid = resp.Substring(indexSid, indexLsid - 5);
            }
        }

        #endregion

        #region New region

        public static TObject JsonToObject<TObject>(string s)
        {
            var serializer = new DataContractJsonSerializer(typeof(TObject));

            TObject data;
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(s)))
            {
                data = (TObject)serializer.ReadObject(stream);
            }
            return data;
        }

        private static string GetResponseText(HttpWebResponse response)
        {
            Stream str = response.GetResponseStream();
            string s;
            using (var sr = new StreamReader(str))
            {
                s = sr.ReadToEnd();
                // Handle JSON data in s

                sr.Close();
            }
            return s;
        }

        private long getUnixTimeNow()
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            var unixTime = (long)ts.TotalSeconds;
            return unixTime;
        }

        #endregion

        #region API

        public bool AddFeed(string feedUrl)
        {
            string data = String.Format("quickadd={0}&T={1}", feedUrl, this.Token);
            const string url = "http://www.google.com/reader/api/0/subscription/quickadd?client=scroll";

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokePost(eventArgs);
            HttpWebResponse response = this.HttpPost(url, data);
            if (response == null) return false;
            return true;
        }

        public bool AddLabelToFeed(string label, string feedUrl)
        {
            string data = String.Format
                ("a=user/-/label/{0}&s=feed/{1}&ac=edit&T={2}", label, feedUrl, this.Token);
            string url = "http://www.google.com/reader/api/0/subscription/edit?client=scroll";

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokePost(eventArgs);
            HttpWebResponse response = this.HttpPost(url, data);

            if (response == null) return false;
            return true;
        }

        public ListAllJson ListAllJson()
        {
            string s = this.ListAll();
            var serializer = new DataContractJsonSerializer(typeof(ListAllJson));

            ListAllJson data;
            using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(s)))
            {
                data = serializer.ReadObject(stream) as ListAllJson;
            }
            return data;
        }

        public UserInfoJson GetUserInfo()
        {
            string url =
                "http://www.google.com/reader/api/0/user-info";
            string args = string.Format
                ("?&ck={0}&client=myApplication", this.getUnixTimeNow());

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokeGet(eventArgs);
            HttpWebResponse response = this.HttpGet(url, args);

            string s = GetResponseText(response);
            return JsonToObject<UserInfoJson>(s);
        }

        public UnreadCountJson GetUnreadCountJson()
        {
            string url =
                "http://www.google.com/reader/api/0/unread-count?allcomments=false&output=json&ck=1255643091105&client=myApplication";
            string args = string.Format
                ("allcomments=false&output=json&ck={0}&client=myApplication", this.getUnixTimeNow());

            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokeGet(eventArgs);
            HttpWebResponse response = this.HttpGet(url, args);

            string s = GetResponseText(response);
            return JsonToObject<UnreadCountJson>(s);
        }

        public string GetTagsJsonText()
        {
            const string url = @"http://www.google.com/reader/api/0/tag/list";
            string args = string.Format("ck={0}&output=json", this.getUnixTimeNow());
            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokeGet(eventArgs);
            HttpWebResponse response = this.HttpGet(url, args);

            string responseText = GetResponseText(response);
            return responseText;
        }
        public TagsJson GetTagsJson()
        {
            return JsonToObject<TagsJson>(GetTagsJsonText());
        }
        private string ListAll()
        {
            string url = string.Format
                ("http://www.google.com/reader/api/0/stream/contents/user/-/" +
                 "state/com.google/reading-list");
            string args = string.Format
                ("ck={0}&client=scroll", this.getUnixTimeNow());
            GoogleReaderClientEventArgs eventArgs = new GoogleReaderClientEventArgs
            {
                Url = url
            };
            InvokeGet(eventArgs);
            HttpWebResponse response = this.HttpGet(url, args);

            string s = GetResponseText(response);
            return s;
        }

        #endregion
    }
}