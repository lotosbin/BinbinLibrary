using System;
namespace ClassLibrary1
{
    public interface IGame
    {
        void ClickBlock(System.Drawing.Point block);
        System.Drawing.Point GetClickBlock(int p1, int p2);
        void Init();
        System.Drawing.Image LoadImage(int p);
    }
}
