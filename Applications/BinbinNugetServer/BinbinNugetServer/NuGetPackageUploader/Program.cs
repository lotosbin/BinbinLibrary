using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using NuGetPackageUploader.nuget;

namespace NuGetPackageUploader
{
    internal class Program
    {
        private const string UploadServiceHostUrl = "http://nuget.alpha.corp.ymatou.com/Upload.ashx";

        private static void Main(string[] args)
        {
            try
            {
                var filePath = args[0];
                string hosturl = UploadServiceHostUrl;
                if (args.Length == 2)
                {
                    hosturl = args[1];
                }
                if (string.IsNullOrEmpty(filePath)) return;
                var file = new DirectoryInfo(filePath).GetFiles("*.nupkg").OrderByDescending(f => f.CreationTime).FirstOrDefault();
                if (file == null) return;
                BinaryReader reader = new BinaryReader(File.Open(file.FullName, FileMode.Open, FileAccess.Read));
                reader.BaseStream.Position = 0;
                byte[] data = reader.ReadBytes(Convert.ToInt32(reader.BaseStream.Length));
                reader.Close();

                var fileName = Path.GetFileName(file.FullName);
                //UploadPackageSoapClient c = new UploadPackageSoapClient();
                //c.Upload(data, fileName);
                var url = hosturl + "?filename=" + fileName;
                UpLoad(data, fileName, url);
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), DateTime.Now + " 成功上传包！" + fileName + Environment.NewLine);
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), DateTime.Now + " 错误！异常消息：" + ex.ToString() + Environment.NewLine);
            }
        }

        public static string UpLoad(byte[] fileBytes, string savedFileName, string uploadServiceHostUrl)
        {
            string result;


            string url = uploadServiceHostUrl;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            using (Stream requestStream = req.GetRequestStream())
            {
                requestStream.Write(fileBytes, 0, fileBytes.Length);
                requestStream.Close();
            }
            using (WebResponse rep = req.GetResponse())
            {
                using (var sr = new StreamReader(rep.GetResponseStream(), encoding: Encoding.Default))
                {
                    result = sr.ReadToEnd();
                }
            }


            return result;
        }
    }
}