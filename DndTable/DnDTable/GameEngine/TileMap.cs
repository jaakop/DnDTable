using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameEngine
{
    public class TileMap
    {
        string tileMapPath;
        int tileSize;
        
        public TileMap()
        {

        }

        public TileMap(string MapPath, int TileSize)
        {
            tileMapPath = MapPath;
            tileSize = TileSize;
        }

        public string TileMapPath { get => tileMapPath; set => tileMapPath = value; }
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

        Image GetImage()
        {
            return Image.FromFile(TileMapPath);
        }
    }
}
