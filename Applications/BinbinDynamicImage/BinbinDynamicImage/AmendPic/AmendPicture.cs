using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Ymatou.Picture.AmendPic
{
    public static class AmendPicture
    {
        private static string newPicRootDirName = "changed";
        public static string ChangePictureSize(string serverRoot, string fullFileName, PictureSize newSize, string generatePath, string merchantId, string appId, string type)
        {
            using (Image img = Image.FromFile(fullFileName))
            {
                if (!Helper.IsNeedChangeSize(newSize, img))
                {
                    return fullFileName;
                }
            }
            string fileName = Path.GetFileName(fullFileName);
            //判断是否有新文件
            //string fileRoot = serverRoot + newPicRootDirName + "\\" + newSize.TypeName + "\\" + fileName;
            var generateName = "default";
            string fileRoot = generatePath + "\\" + merchantId + "\\" + appId + "\\" + type + "\\" + "\\" + generateName + "\\" + fileName;
            if (!File.Exists(serverRoot + newPicRootDirName + "\\" + newSize.TypeName + "\\" + fileName))
            {
                Image oldImg;
                try
                {
                    //获取现有图片
                    oldImg = Image.FromFile(fullFileName);
                }
                catch (OutOfMemoryException ex)
                {
                    throw ex;
                }
                //计算新图片长宽
                int oldHeight = oldImg.Height;
                int oldWidth = oldImg.Width;
                int newHeight = 0;
                int newWidth = 0;

                double thumWidth = oldWidth > newSize.Width ? (double)newSize.Width / (double)oldWidth : 1;
                double thumHeight = oldHeight > newSize.Height ? (double)newSize.Height / (double)oldHeight : 1;
                double thumBoth = thumWidth < thumHeight ? thumWidth : thumHeight;

                switch (newSize.ThumKey)
                {
                    case (int)ThumKeyEnum.Width:
                        newWidth = Convert.ToInt32(oldWidth * thumWidth);
                        newHeight = Convert.ToInt32(oldHeight * thumWidth);
                        break;
                    case (int)ThumKeyEnum.Height:
                        newWidth = Convert.ToInt32(oldWidth * thumHeight);
                        newHeight = Convert.ToInt32(oldHeight * thumHeight);
                        break;
                    case (int)ThumKeyEnum.Both:
                        newWidth = Convert.ToInt32(oldWidth * thumBoth);
                        newHeight = Convert.ToInt32(oldHeight * thumBoth);
                        break;
                    default:
                        break;
                }
                //生成新图并保存
                using (Bitmap bmp = new Bitmap(oldImg, newWidth, newHeight))
                {
                    try
                    {
                        bmp.Save(fileRoot, oldImg.RawFormat);
                    }
                    catch (Exception ex)
                    {
                        return fullFileName;
                    }
                    finally
                    {
                        oldImg.Dispose();
                    }
                }

                ////生成缩略图方法（如果图片中存有缩略图信息则效果会很差）
                //Image thumnailImg = null;
                //ImageCodecInfo imgCodeInfo = GetImageCodeInfo("image/gif");
                //EncoderParameters encodeParameters = new EncoderParameters(1);
                //Bitmap bmp = null;
                //try
                //{
                //    //生成缩略图
                //    thumnailImg = oldImg.GetThumbnailImage(newWidth, newHeight, new Image.GetThumbnailImageAbort(CallBack), IntPtr.Zero);
                //    //提高缩略图质量                    
                //    if (imgCodeInfo != null)
                //    {

                //        encodeParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
                //        bmp = new Bitmap(thumnailImg);
                //        bmp.Save(fileRoot, imgCodeInfo, encodeParameters);
                //        //bmp.Save(@"c:\result.jpg", imgCodeInfo, encodeParameters);
                //    }
                //}
                //catch
                //{
                //    //缩略图异常返回现有文件路径
                //    return fullFileName;
                //}
                //finally
                //{
                //    encodeParameters.Dispose();
                //    encodeParameters = null;
                //    imgCodeInfo = null;
                //    bmp.Dispose();
                //    bmp = null;
                //    thumnailImg.Dispose();
                //    thumnailImg = null;
                //    oldImg.Dispose();
                //    oldImg = null;
                //}
            }
            //返回新图片文件路径
            return fileRoot;
        }

        private static ImageCodecInfo GetImageCodeInfo(string mimeType)
        {
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < encoders.Length; i++)
            {
                if (encoders[i].MimeType == mimeType)
                    return encoders[i];
            }
            return null;
        }

        private static bool CallBack()
        {
            return false;
        }


        public static string AddWaterMark(string serverRoot, string fullFileName, WaterMarkType waterMarkTyp)
        {
            ////生成缩略图方法0，不使用.net的缩略图
            //Bitmap bmp = new Bitmap(newWidth, newHeight);
            //Graphics gr = Graphics.FromImage(bmp);
            //gr.SmoothingMode = SmoothingMode.HighQuality;
            //gr.CompositingQuality = CompositingQuality.HighQuality;
            //gr.InterpolationMode = InterpolationMode.High;
            //Rectangle objRectangle = new Rectangle(0, 0, newWidth, newHeight);
            //try
            //{
            //    gr.DrawImage(oldImg, objRectangle, 0, 0, oldWidth, oldHeight, GraphicsUnit.Pixel);
            //    bmp.Save(fileRoot);
            //}
            //catch (Exception ex)
            //{
            //    return fullFileName;
            //}
            //finally
            //{
            //    bmp.Dispose();
            //    oldImg.Dispose();
            //}

            string fileName = Path.GetFileName(fullFileName);
            Image oldImg;
            Image waterMarkImg;
            try
            {
                //获取现有图片
                oldImg = Image.FromFile(fullFileName);
                //获取水印图片
                waterMarkImg = Image.FromFile(serverRoot + newPicRootDirName + "\\" + waterMarkTyp.WaterMarkDirName + "\\" + waterMarkTyp.WaterMarkName);
            }
            catch (OutOfMemoryException ex)
            {
                throw ex;
            }
            //如果图片过小则不处理
            if (oldImg.Width <= waterMarkImg.Width * 2 || oldImg.Height <= waterMarkImg.Height * 2)
            {
                return fullFileName;
            }
            //判断是否有新文件
            string fileRoot = serverRoot + newPicRootDirName + "\\" + waterMarkTyp.WaterMarkDirName + "\\" + fileName;
            if (!File.Exists(serverRoot + newPicRootDirName + "\\" + waterMarkTyp.WaterMarkDirName + "\\" + fileName))
            {
                Bitmap bmp;
                bmp = new Bitmap(oldImg);
                Graphics gr = Graphics.FromImage(bmp);
                gr.SmoothingMode = SmoothingMode.Default;
                gr.InterpolationMode = InterpolationMode.High;
                Rectangle objRectangle = new Rectangle(oldImg.Width - waterMarkImg.Width, oldImg.Height - waterMarkImg.Height, waterMarkImg.Width, waterMarkImg.Height);
                try
                {
                    gr.DrawImage(waterMarkImg, objRectangle, 0, 0, waterMarkImg.Width, waterMarkImg.Height, GraphicsUnit.Pixel);
                    bmp.Save(fileRoot, oldImg.RawFormat);
                }
                catch (Exception ex)
                {
                    return fullFileName;
                }
                finally
                {
                    gr.Dispose();
                    waterMarkImg.Dispose();
                    bmp.Dispose();
                    oldImg.Dispose();
                }
            }
            return fileRoot;
        }
    }
}