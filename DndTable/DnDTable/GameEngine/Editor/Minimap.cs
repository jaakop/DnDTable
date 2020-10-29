using System.Collections.Generic;
using System.Drawing;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace GameEngine.Editor
{
    /// <summary>
    /// Minimap of a level
    /// </summary>
    public class Minimap
    {
        /// <summary>
        /// Draw a minimap
        /// </summary>
        /// <param name="level">Level from the minimap is made of</param>
        /// <param name="widht">Width of the minimap</param>
        /// <param name="height">Height of the minimap</param>
        /// <param name="tileW">Tile width of the level</param>
        /// <param name="tileH">Tile height of the level</param>
        /// <returns></returns>
        public static Image DrawMinimap(Level.Level level, int widht, int height, int tileW, int tileH)
        {
            Bitmap map = new Bitmap(widht, height);

            //Y coordinate
            for (int j = 0; j < height; j++)
            {
                //X cooridnate
                for (int i = 0; i < widht; i++)
                {
                    List<Level.Tile> tiles = new List<Level.Tile>();

                    foreach (Level.Layer layer in level.Layers)
                    {
                        foreach (Level.Tile tile in layer.Tiles)
                            if (tile.X == i && tile.Y == j) tiles.Add(tile);
                    }

                    Bitmap image = new Bitmap(tileW, tileH);
                    Graphics graphics = Graphics.FromImage(image);

                    for (int ImageId = 0; ImageId < tiles.Count; ImageId++)
                        if (tiles[ImageId].Image != null) graphics.DrawImage(tiles[ImageId].Image, 0, 0, image.Width, image.Height);

                    Color pixel = GetPixel(image);

                    if (pixel.A > 50) pixel = Color.FromArgb(255, pixel.R, pixel.G, pixel.B);

                    map.SetPixel(i, j, pixel);
                }
            }
            return map;
        }

        /// <summary>
        /// Get color of a tile as single pixel
        /// </summary>
        /// <param name="image">tile image</param>
        /// <returns>Pixel color</returns>
        public static Color GetPixel(Image image)
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