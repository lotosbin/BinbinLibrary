using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ymatou.Picture.AmendPic
{
    public class WaterMarkType
    {
        public int PictureType { get; set; }

        public string WaterMarkDirName { get; set; }

        public string WaterMarkName { get; set; }

        public WaterMarkType(int picType,string waterMarkDir,string waterMarkName)
        {
            PictureType = PictureType;
            WaterMarkDirName = waterMarkDir;
            WaterMarkName = waterMarkName;
        }

        public static WaterMarkType ForumWaterMark = new WaterMarkType((int)PictureTypeEnum.Forum, "ForumWaterMarked", "waterMark.png");
    }
}