using System.Collections.Generic;
using System.Drawing;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace GameEngine.Level
{
    /// <summary>
    /// Tile
    /// </summary>
    public class Tile
    {
        private Bitmap image;

        private int x;
        private int y;

        private int tileId;
        private int mapId;

        /// <summary>
        /// A Tile Object
        /// </summary>
        public Tile() {}

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
        /// A Tile Object
        /// </summary>
        /// <param name="X">The X coordinate of the Tile</param>
        /// <param name="Y">The Y coordinate of the Tile</param>
        /// <param name="Image">The image of the Tile</param>
        public Tile(int X, int Y, int TileID, int MapID, Bitmap Image)
        {
            x = X;
            y = Y;

            tileId = TileID;
            mapId = MapID;

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
        /// Draws the
        /// +wireframe of the tile
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
        /// Erases the image of the tile
        /// </summary>
        public void Erase()
        {
            image = null;
        }

        /// <summary>
        /// Load image to tile
        /// </summary>
        /// <param name="maps">Dictionary of map ids and tile image lists</param>
        public void LoadImage(Dictionary<int, List<Image>> maps)
        {
            image = (Bitmap)maps[MapId][TileId];
        }

        /// <summary>
        /// Prepare tile for saving
        /// </summary>
        public void PrepareForSaving()
        {
            image = null;
        }

        /// <summary>
        /// The X coordinate of the tile
        /// </summary>
        public int X { get => x; set => x = value; }

        /// <summary>
        /// The Y coordinate of the tile
        /// </summary>
        public int Y { get => y; set => y = value; }

        /// <summary>
        /// Tile Image
        /// </summary>
        public Image Image { get => image; }
        /// <summary>
        /// Tile id
        /// </summary>
        public int TileId { get => tileId; set => tileId = value; }
        /// <summary>
        /// TileMap id
        /// </summary>
        public int MapId { get => mapId; set => mapId = value; }
    }
}
