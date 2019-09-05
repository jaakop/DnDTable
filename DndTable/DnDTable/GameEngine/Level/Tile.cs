using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace GameEngine.Level
{
    public class Tile
    {
        Bitmap image;
        int x;
        int y;

        public Tile(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public Tile(int X, int Y, Bitmap Image)
        {
            x = X;
            y = Y;
            image = Image;
        }
        public void DrawTile(Graphics g, int size)
        {
            if (image == null)
                return;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(image, x * (size), y * (size), size, size);
            
        }
        public int X { get => x; }
        public int Y { get => y; }
    }
}
