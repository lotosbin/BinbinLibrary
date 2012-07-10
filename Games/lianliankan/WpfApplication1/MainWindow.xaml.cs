using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsFormsApplication1;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.Game = new Game();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Game.Init();
            this.InvalidateVisual();
        }
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            int blockwithd = this.Game.BlockWitdh;
            int boarderwitdh = this.Game.BorderWitdh;

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
                    var rectangle = new Rectangle();
                    rectangle.Width = bxw;
                    rectangle.Height = byh;
                    rectangle.Stroke = System.Windows.Media.Brushes.Black;
                    rectangle.Fill = System.Windows.Media.Brushes.SkyBlue;
                    this.Canvas1.Children.Add(rectangle);
                    Canvas.SetTop(rectangle, by);
                    Canvas.SetLeft(rectangle, bx);
                    //Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
                    //this.Canvas1.
                }

                var image = this.Game.LoadImage(item.PictureId);
                var wpfimage = new System.Windows.Controls.Image();
                wpfimage.Source = BitmapSourceFromImage(image);
                //this.Canvas1.cr
                this.Canvas1.Children.Add(wpfimage);
                Canvas.SetLeft(wpfimage, x);
                Canvas.SetTop(wpfimage, y);
                //e.Graphics.DrawImage(image, x, y, xw, yh);


            }
            this.Label1.Content = this.Game.Score.ToString();
        }
        public static BitmapSource BitmapSourceFromImage(System.Drawing.Image img)
        {

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            //save the image to memStream as a png

            img.Save(memStream, System.Drawing.Imaging.ImageFormat.Png);

            //gets a decoder from this stream

            System.Windows.Media.Imaging.PngBitmapDecoder decoder = new System.Windows.Media.Imaging.PngBitmapDecoder(memStream, System.Windows.Media.Imaging.BitmapCreateOptions.PreservePixelFormat, System.Windows.Media.Imaging.BitmapCacheOption.Default);

            return decoder.Frames[0];

        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定要退出吗？", "退出", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
