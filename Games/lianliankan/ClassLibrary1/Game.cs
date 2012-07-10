using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Properties;

namespace WindowsFormsApplication1
{
    public class Game : ClassLibrary1.IGame
    {
        public Image LoadImage(int p)
        {
            var filename = string.Empty;
            switch (p)
            {
                case 1:
                    
                    return Resources.block__1_;
                case 2:
                    return Resources.block__2_;
                case 3:
                    return Resources.block__3_;
                default:
                    return null;
                    break;
            }
            //var resourcename = "";
            //Resources.block__1_

            //return Image.FromFile("./resources/" + p);
        }
        public Game()
        {
            this.Score = 0;
            this.BlockWitdh = 50;
            this.BorderWitdh = 2;
        }
        public Board Board = new Board();
        public void Init()
        {
            this.Board.Blocks.Clear();
            this.Board.Blocks.Add(new Block()
            {
                Selected = true,
                PictureId = 1,
                x = 1,
                y = 5,
            });
            this.Board.Blocks.Add(new Block()
            {
                PictureId = 2,
                x = 2,
                y = 1,
            });
            this.Board.Blocks.Add(new Block()
            {
                PictureId = 3,
                x = 1,
                y = 2,
            });
            this.Board.Blocks.Add(new Block()
            {
                PictureId = 3,
                x = 1,
                y = 4,
            });
            this.Board.Blocks.Add(new Block()
            {
                PictureId = 3,
                x = 3,
                y = 3,
            });
            this.Board.Blocks.Add(new Block()
            {
                PictureId = 2,
                x = 2,
                y = 2,
            });
        }

        public Point GetClickBlock(int p1, int p2)
        {
            int x = (int)(p1 / this.BlockWitdh);
            int y = (int)(p2 / this.BlockWitdh);
            return new Point(x, y);
        }

        public int BlockWitdh { get; set; }

        public int BorderWitdh { get; set; }

        public void ClickBlock(Point block)
        {
            var clickblock = this.Board.Blocks.Where(b => b.x == block.X && b.y == block.Y).SingleOrDefault();
            if (null != clickblock)
            {
                if (this.Board.Blocks.Count(b => b.Selected) < 2)
                {
                    clickblock.Selected = !clickblock.Selected;
                    if (this.Board.Blocks.Count(b => b.Selected) == 2)
                    {
                        this.CheckSelect();
                    }
                }
                else
                {
                    ClearSelect();
                }
            }
            else
            {
                this.ClearSelect();
            }

        }

        private void CheckSelect()
        {
            var blocks = this.Board.Blocks.Where(b => b.Selected == true).ToList();
            if (CanConnect(blocks))
            {
                RemoveSelect(blocks);
                AddScore();
            }
            else
            {
                ClearSelect();
            }
        }

        private void AddScore()
        {
            this.Score += 10;
        }

        private void RemoveSelect(List<Block> blocks)
        {
            var idlist = blocks.ConvertAll(b => b.RID);
            this.Board.Blocks.RemoveAll(b => idlist.Contains(b.RID));
        }

        private bool CanConnect(List<Block> blocks)
        {

            if (blocks.Count == 2)
            {
                var block1 = blocks[0];
                var block2 = blocks[1];
                if (block1.PictureId == block2.PictureId)
                {
                    //case line1:
                    if (ConnectLine1(block1, block2)) return true;
                    //case line2:
                    {
                        var minx = Math.Min(block1.x, block2.x);
                        var maxx = Math.Max(block1.x, block2.x);
                        var miny = Math.Min(block1.y, block2.y);
                        var maxy = Math.Max(block1.y, block2.y);
                        if (this.Board.NotExistBlock(minx, miny))
                        {
                            var block = new Block()
                            {
                                x = minx,
                                y = miny,
                            };
                            if (ConnectLine1(block1, block) && ConnectLine1(block2, block))
                            {
                                return true;
                            }
                        }
                        if (this.Board.NotExistBlock(maxx, maxy))
                        {
                            var block = new Block()
                            {
                                x = maxx,
                                y = maxy,
                            };
                            if (ConnectLine1(block1, block) && ConnectLine1(block2, block))
                            {
                                return true;
                            }
                        }
                        if (this.Board.NotExistBlock(minx, maxy))
                        {
                            var block = new Block()
                            {
                                x = minx,
                                y = maxy,
                            };
                            if (ConnectLine1(block1, block) && ConnectLine1(block2, block))
                            {
                                return true;
                            }
                        }
                        if (this.Board.NotExistBlock(maxx, miny))
                        {
                            var block = new Block()
                            {
                                x = maxx,
                                y = miny,
                            };
                            if (ConnectLine1(block1, block) && ConnectLine1(block2, block))
                            {
                                return true;
                            }
                        }
                    }
                    //case default:
                    return false;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }

        private bool ConnectLine1(Block block1, Block block2)
        {
            if (block1.x == block2.x || block1.y == block2.y)
            {
                if (block1.x == block2.x)
                {
                    var min = Math.Min(block1.y, block2.y);
                    var max = Math.Max(block1.y, block2.y);
                    return this.Board.Blocks.Where(b => b.x == block1.x && b.y > min && b.y < max).Count() == 0;
                }
                if (block1.y == block2.y)
                {
                    var min = Math.Min(block1.x, block2.x);
                    var max = Math.Max(block1.x, block2.x);
                    return this.Board.Blocks.Where(b => b.y == block1.y && b.x > min && b.x < max).Count() == 0;
                }

            } return false;
        }

        private void ClearSelect()
        {
            this.Board.Blocks.ForEach(b => b.Selected = false);
        }

        public int Score { get; set; }

        public Image GetBackgroudImage()
        {
            return Resources.bg01;
        }
    }
}
