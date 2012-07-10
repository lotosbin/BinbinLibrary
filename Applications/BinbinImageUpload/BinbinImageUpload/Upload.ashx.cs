using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using BinbinImageUpload.Properties;
namespace BinbinImageUpload
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            {
                //获取上传图片名称
                string picName = (context.Request.QueryString["filename"] ?? Guid.NewGuid().ToString("N")).ToString();
                //上传图片类型
                string picType = (context.Request.QueryString["type"] ?? "default").ToString().ToLower();
                //商户Id
                string merchantId = (context.Request.QueryString["merchantId"] ?? Guid.Empty.ToString("N")).ToString();
                //应用Id
                string appId = (context.Request.QueryString["appId"] ?? Guid.Empty.ToString("N")).ToString();
                string result = "";


                {
                    //根据图片类型确定存储路径
                    string pathOriginal = Settings.Default.OriginalPath + merchantId + "\\" + appId + "\\" + picType + "\\" + "original\\";
                    //if (picType.Equals("product") || picType.Equals("userlogo"))
                    //{
                    //    pathOriginal = pathOriginal + "original\\";
                    //    picName = picName.Replace("_o", "");
                    //    picName = picName.Substring(0, picName.IndexOf('.')) + "_o" + picName.Substring(picName.IndexOf('.'));
                    //}
                    DirectoryInfo drOriginal = new DirectoryInfo(pathOriginal);
                    if (!drOriginal.Exists)
                    {
                        try
                        {
                            drOriginal.Create();
                        }
                        catch (Exception ex)
                        {
                            context.Response.Write(ex.Message.ToString());
                            return;
                        }
                    }

                    //获得上传图片文件流
                    using (Stream uploadStream = context.Request.InputStream)
                    {
                        //保存上传的图片文件
                        using (FileStream inputStream = File.Create(pathOriginal + picName))
                        {
                            try
                            {
                                int bufSize = 1024;
                                int byteGet = 0;
                                byte[] buf = new byte[bufSize];
                                while ((byteGet = uploadStream.Read(buf, 0, bufSize)) > 0)
                                {
                                    inputStream.Write(buf, 0, byteGet);
                                }
                            }
                            catch (Exception ex)
                            {
                                result = result + ex.Message.ToString();
                            }
                        }

                        uploadStream.Close();
                    }
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(Settings.Default.ImageHostUrl + merchantId + "/" + appId + "/" + picType + "/" + "original/" + picName);
                    return;
                    ////图片上传成功，并且是产品图片，则对图片进行处理
                    //if (string.IsNullOrEmpty(result) && picType.Equals("product"))
                    //{
                    //    string listSizeResult = changeProductPicSize(pathOriginal + picName, 160, "list", 'l');
                    //    string smallSizeResult = changeProductPicSize(pathOriginal + picName, 320, "small", 's');
                    //    string bigSizeResult = changeProductPicSize(pathOriginal + picName, 800, "big", 'b');

                    //    context.Response.Write("http://p3.img.ymatou.com/upload/" + picType + "/original/" + picName);
                    //}
                    //else if (string.IsNullOrEmpty(result) && picType.Equals("userlogo"))  //用户图片
                    //{
                    //    string smallSizeResult = changeProductPicSize(pathOriginal + picName, 40, "small", 's');
                    //    string middleSizeResult = changeProductPicSize(pathOriginal + picName, 120, "middle", 'm');

                    //    context.Response.Write("http://p3.img.ymatou.com/upload/" + picType + "/original/" + picName);
                    //}
                    //else if (string.IsNullOrEmpty(result))
                    //{
                    //    context.Response.Write("http://p3.img.ymatou.com/upload/" + picType + "/" + picName);
                    //}
                    //else
                    //{
                    //    context.Response.Write(result);
                    //}
                }
                context.Response.Write(result);
            }
            //else
            //{
            //    context.Response.Write("");
            //}
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 生成产品缩略图
        /// </summary>
        /// <param name="picName">图片文件名（带路径）</param>
        /// <param name="size">生成图片的尺寸</param>
        /// <param name="toType">生成图片的类型（list,small,big）</param>
        /// <param name="shotType">类型缩写（list:l ,small:s, big:b）</param>
        /// <returns></returns>
        private string changeProductPicSize(string picName, int size, string toType, char shotType)
        {
            string result = "";
            MemoryStream ms = new MemoryStream();
            using (Bitmap bmp = new Bitmap(picName))
            {
                int oWidth = bmp.Width;
                int oHeight = bmp.Height;
                int toWidth = 0;
                int toHeight = 0;
                if (oWidth > oHeight)
                {
                    toHeight = oHeight * size / oWidth;
                    toWidth = size;
                }
                else
                {
                    toWidth = oWidth * size / oHeight;
                    toHeight = size;
                }

                using (System.Drawing.Image img = bmp.GetThumbnailImage(toWidth, toHeight, null, IntPtr.Zero))
                {
                    switch (picName.Substring(picName.LastIndexOf('.') + 1).ToUpper())
                    {
                        case "JPG":
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "PNG":
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case "BMP":
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "GIF":
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        default:
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                    }
                }
            }

            string sPicName = picName.Substring(picName.LastIndexOf("\\") + 1);
            sPicName = sPicName.Replace('o', shotType);
            string toFileName = picName.Substring(0, picName.LastIndexOf("\\"));
            toFileName = toFileName.Replace("original", toType);

            DirectoryInfo dr = new DirectoryInfo(toFileName);
            if (!dr.Exists)
            {
                dr.Create();
            }

            toFileName = toFileName + "\\" + sPicName;

            using (Stream outStream = System.IO.File.Create(toFileName))
            {
                try
                {
                    ms.WriteTo(outStream);
                }
                catch (ArgumentNullException ex)
                {
                    throw ex;
                }
                finally
                {
                    ms.Close();
                }
            }
            return result;
        }

    }
}