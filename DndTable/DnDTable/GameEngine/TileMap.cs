using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DnDTable.GameEngine.Tools
{
    public class TileMap
    {
        string tileMapPath;
        int tileSize;

        public TileMap(string MapPath, int TileSize)
        {
            tileMapPath = MapPath;
            tileSize = TileSize;
        }

        /// <summary>
        /// Slices Images form a TileMap
        /// </summary>
        /// <returns>List of images sliced from the tilemap (in order L2R & T2B)</returns>
        public List<Image> SliceTileMap()
        {

            return null;
        }

        Image GetImage()
        {
            return Image.FromFile(@tileMapPath);
        }
    }
}
