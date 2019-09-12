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
        /// <summary>
        /// A Level Object
        /// </summary>
        public Level()
        {
            layers = new List<Layer>();
        }
        /// <summary>
        /// Add a layer to the lavel
        /// </summary>
        /// <param name="layerToAdd">The layer to be added</param>
        public void AddALayer(Layer layerToAdd)
        {
            layers.Add(layerToAdd);
        }
        /// <summary>
        /// Draw the level
        /// </summary>
        /// <param name="g">Graphics to draw on</param>
        /// <param name="TileSize">The size of the tiles to be drawn</param>
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
        /// <summary>
        /// Returns the layer list of the level
        /// </summary>
        public List<Layer> Layers { get => layers; }

    }
}
