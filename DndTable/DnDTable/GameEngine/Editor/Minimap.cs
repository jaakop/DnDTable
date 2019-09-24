using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace GameEngine.Editor
{
    public class Minimap
    {
        public static Image DrawMinimap(Level.Level level, int widht, int height, int tileW, int tileH)
        {
            Bitmap map = new Bitmap(widht, height);
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < widht; i++)
                {
                        List<Level.Tile> tiles = new List<Level.Tile>();
                    foreach(Level.Layer layer in level.Layers)
                    { 
                        foreach(Level.Tile tile in layer.Tiles)
                        {
                            if(tile.X == i && tile.Y == j)
                            {
                                tiles.Add(tile);
                            }
                        }
                    }
                        Bitmap image = new Bitmap(tileW, tileH);
                        Graphics graphics = Graphics.FromImage(image);
                        for(int ImageId = 0; ImageId < tiles.Count; ImageId++)
                        {
                            if(tiles[ImageId].Image != null)
                                graphics.DrawImage(tiles[ImageId].Image, 0, 0, image.Width, image.Height);
                        }
                    Color pixel = GetPixel(image);
                    if(pixel.A > 50)
                    {
                    pixel = Color.FromArgb(255, pixel.R, pixel.G, pixel.B);

                    }
                        map.SetPixel(i, j, pixel);
                }
            }
            return map;
        }

        static Color GetPixel(Image image)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, 1, 1);
            };
            Color color = bitmap.GetPixel(0, 0);
            return color;
        }
    }
}