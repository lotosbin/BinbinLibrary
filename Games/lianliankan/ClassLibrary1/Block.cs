using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Block
    {
        public Guid RID = Guid.NewGuid();
        public int PictureId = 1;
        public int x { get; set; }

        public int y { get; set; }
        public bool Selected { get; set; }
        public bool IsSelected()
        {
            return Selected;
        }
    }
}
