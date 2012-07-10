using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using WebBrowser = System.Windows.Controls.WebBrowser;

namespace GGameAssist.WpfApplication.Models
{
    class WebsiteModel
    {
    }

    class BaiduWebsiteModel : WebsiteModel
    {
        public BaiduWebsiteModel(WebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }

        public WebBrowser WebBrowser { get; set; }
        public CookieContainer CookieContaner = new CookieContainer();
        public string Login(WebBrowser browser, string loginUrl, string username, string password)
        {
            browser.LoadCompleted += new System.Windows.Navigation.LoadCompletedEventHandler(browser_LoadCompleted);
            browser.Navigate(loginUrl);
            return string.Empty;
        }

        private bool c = false;
        void browser_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            HtmlDocument document = (HtmlDocument) this.WebBrowser.Document ;
             var collection = document.GetElementsByTagName("input");
            foreach (HtmlElement element in collection)
            {
                if (element.Name=="username")
                {
                    element.InnerText = "lotosbin";
                }
                if (element.Name == "password")
                {
                    element.InnerText = "binbinliu1985";
                }
            }
        }

        public string Login(string loginUrl, string username, string password)
        {
            //Host	passport.baidu.com
            //User-Agent	Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3
            //Accept	text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
            //Accept-Language	zh-cn,zh;q=0.5
            //Accept-Encoding	gzip,deflate
            //Accept-Charset	GB2312,utf-8;q=0.7,*;q=0.7
            //Keep-Alive	115
            //Connection	keep-alive
            string s =
                "tpl_ok=&next_target=&tpl=sp&skip_ok=&aid=&need_pay=&need_coin=&pay_method=&u=http%3A%2F%2Fhi.baidu.com%2F{0}&fu=http%3A%2F%2Fhi.baidu.com%2Fst%2Floginok.html&return_method=get&more_param=&return_type=&psp_tt=2&password={1}&safeflg=0&username={0}&verifycode=";
            //string param = string.Format(s, username, password);
            string param = string.Empty;
            byte[] data = Encoding.ASCII.GetBytes(param);
            var uri = new Uri(loginUrl);
            var request = WebRequest.Create(uri) as HttpWebRequest;
            request.CookieContainer = CookieContaner;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            //request.Host = "passport.baidu.com";
            //request.UserAgent =
            //    "Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-CN; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3";
            //request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            //request.Headers.Add("Accept-Language", "zh-cn,zh;q=0.5");
            //request.Headers.Add("Accept-Encoding", "gzip,deflate");
            //request.Headers.Add("Accept-Charset", "GB2312,utf-8;q=0.7,*;q=0.7");
            //request.Headers.Add("Keep-Alive", "115");
            //request.KeepAlive = false;
            //request.Connection = "keep-alive";

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }
            var response = request.GetResponse();
            string r = string.Empty;
            using (var responseStream = response.GetResponseStream())
            {
                var sr = new StreamReader(responseStream);
                r = sr.ReadToEnd();
            }
            return r;
        }
    }
}
