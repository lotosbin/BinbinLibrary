using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ymatou.Picture.AmendPic;
using System.Globalization;
using Binbin.DynamicImage.Properties;
namespace Binbin.DynamicImage
{
    public class PictureController : Controller
    {
        //
        // GET: /ForumPicture/

        public ActionResult Index(string merchantId, string appId, string type, string filename)
        {
            //获取论坛图片路径

            string filePath = Settings.Default.UploadPath + "\\" + merchantId + "\\" + appId + "\\" + type + "\\original\\" + filename;
            string fileAbsPath = filePath;
            string serverAbsPath = this.Server.MapPath("~/");
            if (!System.IO.File.Exists(fileAbsPath))
            {
                return this.File(serverAbsPath + "null.gif", "image/jpg");
            }
            //缩放图片
            string picturePath = string.Empty;
            try
            {
                picturePath = AmendPicture.ChangePictureSize(serverAbsPath, fileAbsPath, PictureSize.ForumMax,Settings.Default.GeneratePath,merchantId,appId,type);
            }
            catch (OutOfMemoryException ex)
            {
            }

            //if (string.IsNullOrEmpty(picturePath) == false)
            //{
            //    //生成水印图片
            //    try
            //    {
            //        picturePath = AmendPicture.AddWaterMark(serverAbsPath, picturePath, WaterMarkType.ForumWaterMark);
            //    }
            //    catch (OutOfMemoryException ex)
            //    {
            //        picturePath = serverAbsPath + "null.gif";
            //    }
            //}
            //else
            //{
            //    picturePath = serverAbsPath + "null.gif";
            //}

            Response.ClearHeaders();
            Response.Headers.Add("Last-Modified", GetLastModifiedDate(picturePath));

            return this.File(picturePath, "image/jpg");
        }

        private string GetLastModifiedDate(string fileName)
        {
            return new FileInfo(fileName).LastWriteTime.ToString("F", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
