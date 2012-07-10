using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Ymatou.Picture.AmendPic
{
    public static class Helper
    {
        public static bool IsNeedChangeSize(PictureSize picSize,Image img)
        {
            bool flag = false;
            if (picSize.ThumKey == (int)ThumKeyEnum.Width && img.Width > picSize.Width)
                flag = true;
            if (picSize.ThumKey == (int)ThumKeyEnum.Height && img.Height > picSize.Height)
                flag = true;
            if (picSize.ThumKey == (int)ThumKeyEnum.Both && (img.Width > picSize.Width || img.Height > picSize.Height))
                flag = true;
            return flag;
        }
    }
}