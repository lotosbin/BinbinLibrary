using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Ymatou.Picture.AmendPic
{
    public class PictureSize
    {
        public int PictureType { get; set; }

        public string TypeName { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int ThumKey { get; set; }

        public PictureSize(int picType, string typeName, int width, int height, int thumkey)
        {
            PictureType = picType;
            TypeName = typeName;
            Width = width;
            Height = height;
            ThumKey = thumkey;
        }

        public static PictureSize ForumMax = new PictureSize((int)PictureTypeEnum.Forum, "ForumMaxPic", 100, 0, (int)ThumKeyEnum.Width);
    }
}