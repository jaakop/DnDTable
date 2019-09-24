﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Level
{
    public class Level
    {
        List<Layer> layers;
        List<TileMap> maps;

        /// <summary>
        /// A Level Object
        /// </summary>
        public Level()
        {
            layers = new List<Layer>();
            maps = new List<TileMap>();
        }
        /// <summary>
        /// A Level Object
        /// </summary>
        public Level(List<Layer> layerList, List<TileMap> mapList)
        {
            layers = layerList;
            maps = mapList;
        }


        /// <summary>
        /// Add a layer to the lavel
        /// </summary>
        /// <param name="layerToAdd">The layer to be added</param>
        public void AddALayer(Layer layerToAdd)
        {
            layers.Add(layerToAdd);
        }

        public void AddAMap(TileMap map)
        {
            maps.Add(map);
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

        public void PrepareForSaving()
        {
            foreach(Layer layer in layers)
            {
                for (int i = 0; i < layer.Tiles.Count; i++)
                {
                    if(layer.Tiles[i].Image != null)
                    {
                        layer.Tiles[i].PrepareForSaving();
                        continue;
                    }
                        layer.Tiles.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Returns the layer list of the level
        /// </summary>
        public List<Layer> Layers { get => layers; set => layers = value; }

        public List<TileMap> Maps { get => maps; set => maps = value; }

    }
}
