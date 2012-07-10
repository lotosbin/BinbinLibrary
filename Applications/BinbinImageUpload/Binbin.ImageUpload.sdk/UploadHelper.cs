using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Binbin.ImageUpload.Properties;

namespace Binbin.ImageUpload
{
    public class UploadHelper
    {
        public static string UploadImage(HttpPostedFileBase postedFile, string type, string filename, out string error)
        {
            var merchantId = Settings.Default.MerchantId;
            var appId = Settings.Default.AppId;
            return UploadImage(postedFile, merchantId, appId, type, filename, out error);
        }
        public static string UploadImage(HttpPostedFileBase postedFile, string merchantId, string appId, string type, string filename, out string error)
        {

            string result = "";
            error = "";

            string fileExt = Path.GetExtension(postedFile.FileName).ToLower();
            if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".png")
            {
                byte[] bt = new byte[postedFile.ContentLength];
                try
                {
                    postedFile.InputStream.Read(bt, 0, bt.Length);
                    postedFile.InputStream.Close();
                    string url = Settings.Default.ApiHostUrl + "?merchantId=" + merchantId + "&appId=" + appId + "&type=" + type + "&filename=" + filename;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(bt, 0, bt.Length);
                    requestStream.Close();
                    using (WebResponse rep = req.GetResponse())
                    {
                        using (var sr = new StreamReader(rep.GetResponseStream(), System.Text.Encoding.Default))
                        {
                            result = sr.ReadToEnd();
                        }
                    }

                    req.Abort();
                }
                catch (Exception ex)
                {
                    error = ex.Message.ToString();
                }
            }
            else
            {
                error = "上传图片格式错误。";
            }
            return result;



        }
    }
}
