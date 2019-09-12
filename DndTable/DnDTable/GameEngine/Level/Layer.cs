using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Level
{
    public class Layer
    {
        List<Tile> tiles;
        /// <summary>
        /// A layer witch contains tiles
        /// </summary>
        public Layer()
        {
            tiles = new List<Tile>();
        }
        /// <summary>
        /// Adds a tile
        /// </summary>
        /// <param name="tileToAdd">Tile to be added to the list (if tiles exist there it will be replaced)</param>
        public void AddTile(Tile tileToAdd)
        {
            int i = 0;
            foreach(Tile tile in tiles)
            {
                if (tile.X == tileToAdd.X && tile.Y == tileToAdd.Y)
                {
                    tiles[i] = tileToAdd;
                    return;
                }
                i++;
            }
            tiles.Add(tileToAdd);
        }
        /// <summary>
        /// Returns the tile list of the layer
        /// </summary>
        public List<Tile> Tiles { get => tiles; }
    }
}
