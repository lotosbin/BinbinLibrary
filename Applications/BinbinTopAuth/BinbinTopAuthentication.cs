using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using BinbinTopAuth.Properties;

namespace BinbinTopAuth
{
    public static class BinbinTopAuthentication
    {
        public static string GetAuthUrl()
        {
            if (Settings.Default.UseSandbox)
            {
                return string.Format(" https://oauth.taobao.com/authorize?response_type=code&client_id={0}&redirect_uri={1}", Settings.Default.AppKey, Settings.Default.ReturnUrl);
            }
            return string.Format("http://container.api.tbsandbox.com/container?appkey={0}", Settings.Default.AppKey);
        }
        public static string GetToken(string code)
        {
            /*
             必须传的参数有：
grant_type： 授权类型 authorization_code 或者 refresh_token；
code： 授权请求中的授权码,即第一步获取到的code；
redirect_uri：应用的回调地址；
client_id：客户标识，即appkey；
client_secret：客户密钥，即appsecret；
             */
            if (Settings.Default.UseSandbox)
            {
                //using (var client = new WebClient())
                //{
                //    var stream = client.OpenWrite("https://oauth.tbsandbox.com/token");
                //    var sw = new StreamWriter(stream);
                //    sw.Write("grant_type=authorization_code&code={0}&redirect_uri={1}&client_id={2}&client_secret={3}",code,Settings.Default.TokenReturnUrl,Settings.Default.AppKey,Settings.Default.Secret);
                //    sw.Flush();
                //    client.
                //}
                //return string.Format("https://oauth.tbsandbox.com/token?");
                string parameters = string.Format(
                    "grant_type=authorization_code&code={0}&redirect_uri={1}&client_id={2}&client_secret={3}",
                    code, Settings.Default.TokenReturnUrl, Settings.Default.AppKey,
                    Settings.Default.Secret);
                return HttpPost("https://oauth.tbsandbox.com/token",parameters);
            }
            return string.Empty;
        }
        public static string HttpPost(string URI, string Parameters)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            //req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
    }
}
