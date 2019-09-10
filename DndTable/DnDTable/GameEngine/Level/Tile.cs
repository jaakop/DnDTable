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

        public void DrawTile(Graphics g, int X, int Y, int size, int OffSet)
        {
            if (image == null)
                return;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(image, X * (size + OffSet), Y * (size + OffSet), size + 1, size + 1);
        }

        public void DrawWireFrame(Graphics g, int size)
        {
            g.DrawRectangle(Pens.Black, x * size, y * size, size, size);
        }
        
        public void DrawWireFrame(Graphics g, int X, int Y, int size, int OffSet)
        {
            g.DrawRectangle(Pens.Black, X * (size + OffSet), Y * (size + OffSet), size, size);
        }

        public void HighLight(Graphics g, int X, int Y, int size, bool highlight)
        {
            if (image != null)
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.DrawImage(image, X * (size), Y * (size), size + 1, size + 1);
            }
            else
            {
                g.FillRectangle(Brushes.White, new Rectangle(X * size, Y * size, size + 1, size + 1));
            }
            if (highlight)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(50, Color.LightBlue));
                g.FillRectangle(brush, new Rectangle(X * size, Y * size, size + 1, size + 1));
            }
            g.DrawRectangle(Pens.Black, X * size, Y * size, size, size);
        }

        public int X { get => x; }
        public int Y { get => y; }
    }
}
