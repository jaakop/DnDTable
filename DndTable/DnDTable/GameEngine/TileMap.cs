using System.Collections.Generic;
using System.Drawing;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace GameEngine
{
    /// <summary>
    /// TileMap to store tilemap image
    /// </summary>
    public class TileMap
    {
        private string tileMapPath;
        private int tileSize;
        
        /// <summary>
        /// New TileMap
        /// </summary>
        public TileMap() {}

        /// <summary>
        /// New TileMap
        /// </summary>
        /// <param name="MapPath">Path to tilemap image</param>
        /// <param name="TileSize">Size of the tiles</param>
        public TileMap(string MapPath, int TileSize)
        {
            tileMapPath = MapPath;
            tileSize = TileSize;
        }

        /// <summary>
        /// TileMap Path
        /// </summary>
        public string TileMapPath { get => tileMapPath; set => tileMapPath = value; }
        /// <summary>
        /// Tile size
        /// </summary>
        public int TileSize { get => tileSize; set => tileSize = value; }

        /// <summary>
        /// Slices Images form a TileMap
        /// </summary>
        /// <returns>List of images sliced from the tilemap (in order L2R & T2B)</returns>
        public List<Image> SliceTileMap()
        {
            Bitmap tilemap = (Bitmap)GetImage();
            System.Drawing.Imaging.PixelFormat format = tilemap.PixelFormat;

            List<Image> images = new List<Image>();

            int tilesX = tilemap.Width / TileSize;
            int tilesY = tilemap.Height / TileSize;

            for (int j = 0; j < tilesY; j++)
            {
                for (int i = 0; i < tilesX; i++)
                {
                    Image image = tilemap.Clone(new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize), format);
                    images.Add(image);
                }
            }

            return images;
        }

        /// <summary>
        /// Get tilamp image
        /// </summary>
        /// <returns>image</returns>
        private Image GetImage()
        {
            return Image.FromFile(TileMapPath);
        }
    }
}
