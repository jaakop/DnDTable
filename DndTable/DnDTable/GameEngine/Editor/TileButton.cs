using System.Drawing;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace GameEngine.Editor
{
    /// <summary>
    /// Basic button with properties of a tile stored
    /// </summary>
    public class TileButton : Button
    {
        /// <summary>
        /// New tileButton
        /// </summary>
        /// <param name="ImageId">Tile image id</param>
        /// <param name="MapId">Tilemap id</param>
        /// <param name="image">Tile image</param>
        public TileButton(int ImageId, int MapId, Image image)
        {
            TileId = ImageId;
            this.MapId = MapId;
            BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// Tile Image id
        /// </summary>
        public int TileId { get; }
        /// <summary>
        /// TileMap id
        /// </summary>
        public int MapId { get; }
    }
}
