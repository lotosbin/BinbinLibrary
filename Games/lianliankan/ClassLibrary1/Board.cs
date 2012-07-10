using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ClassLibrary1.Properties;

namespace WindowsFormsApplication1
{
    
    public class Board
    {
        int witdh = 10;
        int height = 10;
        public List<Block> Blocks = new List<Block>();

        internal bool NotExistBlock(int minx, int miny)
        {
            return this.Blocks.Where(b => b.x == minx && b.y == miny).Count() == 0;
        }
    }
}
