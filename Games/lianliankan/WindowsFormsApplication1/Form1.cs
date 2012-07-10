using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1.Properties;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Game = new Game();

        }


        public Game Game { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Game.Init();
            this.BackgroundImage = this.Game.GetBackgroudImage();
            RenderGame();
        }

        private void RenderGame()
        {
            this.Invalidate();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int blockwithd = this.Game.BlockWitdh;
            int boarderwitdh = this.Game.BorderWitdh;
            base.OnPaint(e);
            foreach (var item in this.Game.Board.Blocks)
            {
                int x = item.x * blockwithd + boarderwitdh;
                int xw = blockwithd - 2 * boarderwitdh;
                int y = item.y * blockwithd + boarderwitdh;
                int yh = blockwithd - 2 * boarderwitdh;
                if (item.IsSelected())
                {
                    int bx = item.x * blockwithd;
                    int by = item.y * blockwithd;
                    int bxw = blockwithd;
                    int byh = blockwithd;
                    Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
                    e.Graphics.DrawRectangle(blackPen, bx, by, bxw, byh);
                }

                var image = this.Game.LoadImage(item.PictureId);

                e.Graphics.DrawImage(image, x, y, xw, yh);


            }
            this.label1.Text = this.Game.Score.ToString();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var block = this.Game.GetClickBlock(e.X, e.Y);
            this.Game.ClickBlock(block);
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
