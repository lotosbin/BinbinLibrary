using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace RenrenRESTful
{
    /// <summary>
    /// REST方式的HTTP请求客户端。
    /// </summary>
    public class RESTClient
    {
        const string XIAONEI_API_HOST = "http://api.renren.com/restserver.do";

        /// <summary>
        /// 获取用于请求的参数。
        /// </summary>
        public IDictionary<string, string> Parameters { get; private set; }

        /// <summary>
        /// 创建一个 RESTClient 类的实例。
        /// </summary>
        public RESTClient()
        {
            this.Parameters = new Dictionary<string, string>();
        }

        /// <summary>
        /// 获取响应的数据流。
        /// </summary>
        /// <returns></returns>
        public Stream GetResponseStream()
        {
            var query = CollectionUtil.ToQueryString(this.Parameters);

            var data = Encoding.UTF8.GetBytes(query);

            var request = (HttpWebRequest)WebRequest.Create(XIAONEI_API_HOST);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
                stream.Write(data, 0, data.Length);

            return request.GetResponse().GetResponseStream();
        }

        /// <summary>
        /// 获取响应的文本。
        /// </summary>
        /// <returns></returns>
        public string GetResponseText()
        {
            var text = string.Empty;

            using (var reader = new StreamReader(this.GetResponseStream(), Encoding.UTF8))
                text = reader.ReadToEnd();

            return text;
        }
    }
}