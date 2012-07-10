<%@ WebHandler Language="C#" Class="BHUploadPicture" %>

using System.Configuration;
using System.Web;
using System.IO;

public class Upload : IHttpHandler
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        var filename = context.Request.QueryString["filename"];
        //根据图片类型确定存储路径
        string pathOriginal = context.Server.MapPath(ConfigurationManager.AppSettings["packagesPath"]);

        DirectoryInfo drOriginal = new DirectoryInfo(pathOriginal);
        if (!drOriginal.Exists)
        {
            drOriginal.Create();
        }

        //获得上传图片文件流
        using (Stream uploadStream = context.Request.InputStream)
        {
            using (FileStream inputStream = File.Create(Path.Combine(pathOriginal, filename)))
            {
                int bufSize = 1024;
                int byteGet = 0;
                byte[] buf = new byte[bufSize];
                while ((byteGet = uploadStream.Read(buf, 0, bufSize)) > 0)
                {
                    inputStream.Write(buf, 0, byteGet);
                }
            }

            uploadStream.Close();
        }

        context.Response.ContentType = "text/plain";
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}