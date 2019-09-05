using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Level
{
    public class Layer
    {
        List<Tile> tiles;
        public Layer()
        {
            tiles = new List<Tile>();
        }
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
        public List<Tile> Tiles { get => tiles; }
    }
}
