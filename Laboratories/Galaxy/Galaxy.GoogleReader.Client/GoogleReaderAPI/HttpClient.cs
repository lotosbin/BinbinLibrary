using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace GoogleReaderAPI
{
    public class HttpClient
    {
        public static string Post(string url, object data)
        {
            var response = (HttpWebResponse) CreatePostRequest(url, data).GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        public static HttpWebRequest CreatePostRequest(string url, object data)
        {
            string formData = string.Empty;
            GetProperties(data).ToList().ForEach(
                x => { formData += string.Format("{0}={1}&", x.Name.TrimStart('_'), x.GetValue(data, null)); });
            formData = formData.TrimEnd('&');

            // Prepare web request...
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "POST";

            byte[] encodedData = new ASCIIEncoding().GetBytes(formData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = encodedData.Length;

            using (Stream newStream = request.GetRequestStream())
            {
                newStream.Write(encodedData, 0, encodedData.Length);
            }

            return request;
        }

        public static string Get(string url)
        {
            return Get(url, new {});
        }

        public static string Get(string url, object data)
        {
            var response = (HttpWebResponse) CreateGetRequest(url, data).GetResponse();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString());
            }

            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        public static HttpWebRequest CreateGetRequest(string url, object data)
        {
            string paramData = string.Empty;
            GetProperties(data).ToList().ForEach(
                x => { paramData += string.Format("{0}={1}&", x.Name.TrimStart('_'), x.GetValue(data, null)); });
            paramData = paramData.TrimEnd('&');

            HttpWebRequest request = paramData.Length > 0
                                         ? (HttpWebRequest) WebRequest.Create(string.Format("{0}?{1}", url, paramData))
                                         : (HttpWebRequest) WebRequest.Create(url);
            return request;
        }

        private static PropertyInfo[] GetProperties(object o)
        {
            return
                o.GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic |
                                          BindingFlags.Public);
        }
    }
}