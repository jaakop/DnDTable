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

        /// <summary>
        /// A Tile Object
        /// </summary>
        /// <param name="X">The X coordinate of the Tile</param>
        /// <param name="Y">The Y coordinate of the Tile</param>
        public Tile(int X, int Y)
        {
            x = X;
            y = Y;
        }
        /// <summary>
        /// A Tile Object
        /// </summary>
        /// <param name="X">The X coordinate of the Tile</param>
        /// <param name="Y">The Y coordinate of the Tile</param>
        /// <param name="Image">The image of the Tile</param>
        public Tile(int X, int Y, Bitmap Image)
        {
            x = X;
            y = Y;
            image = Image;
        }
        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="size">Size of the drawn tile</param>
        public void DrawTile(Graphics g, int size)
        {
            if (image == null)
                return;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(image, x * (size), y * (size), size, size);
            
        }
        /// <summary>
        /// Draws the tile
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="X">The X coordinate to draw the tile to</param>
        /// <param name="Y">The Y coordinate to draw the tile to</param>
        /// <param name="size">The size of the drawn tile</param>
        /// <param name="OffSet">Pixels of offset for the tile</param>
        public void DrawTile(Graphics g, int X, int Y, int size, int OffSet)
        {
            if (image == null)
                return;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.DrawImage(image, X * (size + OffSet), Y * (size + OffSet), size + 1, size + 1);
        }
        /// <summary>
        /// Draws the wireframe of the tile
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="size">Size of the drawn tile wireframe</param>
        public void DrawWireFrame(Graphics g, int size)
        {
            g.DrawRectangle(Pens.Black, x * size, y * size, size, size);
        }
        /// <summary>
        /// Draws the wireframe of the tile
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="X">The X coordinate to draw the tile wireframe to</param>
        /// <param name="Y">The Y coordinate to draw the tile wireframe to</param>
        /// <param name="size">The size of the drawn tile wireframe</param>
        /// <param name="OffSet">Pixels of offset for the tile wireframe</param>
        public void DrawWireFrame(Graphics g, int X, int Y, int size, int OffSet)
        {
            g.DrawRectangle(Pens.Black, X * (size + OffSet), Y * (size + OffSet), size, size);
        }
        /// <summary>
        /// Highlights the tile
        /// </summary>
        /// <param name="g">Graphics to draw the highlight to</param>
        /// <param name="X">The X coordinate to draw to</param>
        /// <param name="Y">The Y coordinate to draw to</param>
        /// <param name="size">The size of the drawn tile</param>
        /// <param name="highlight">Is the tile highlighted or not</param>
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
        /// <summary>
        /// The X coordinate of the tile
        /// </summary>
        public int X { get => x; }
        /// <summary>
        /// The Y coordinate of the tile
        /// </summary>
        public int Y { get => y; }
    }
}
