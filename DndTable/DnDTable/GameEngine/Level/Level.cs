using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Level
{
    public class Level
    {
        List<Layer> layers;
        public Level()
        {
            layers = new List<Layer>();
        }

        public void AddALayer(Layer layerToAdd)
        {
            layers.Add(layerToAdd);
        }

        public void DrawLevel(Graphics g, int TileSize)
        {
            foreach(Layer layer in layers)
            {
                foreach(Tile tile in layer.Tiles)
                {
                    tile.DrawTile(g, TileSize);
                }
            }
        }

        public List<Layer> Layers { get => layers; }

    }
}
