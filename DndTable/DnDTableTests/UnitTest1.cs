using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameEngine;
using GameEngine.Editor;
using GameEngine.Level;

namespace DnDTableTests
{
    [TestClass]
    public class GameEngineTests
    {
        [TestMethod]
        public void PrepareLevelTest()
        {
            List<Tile> tiles = new List<Tile>();
            for (int i = 0; i < 500; i++)
                    tiles.Add(new Tile());

            Level lvl = new Level();
            lvl.AddALayer(new Layer(tiles));
            lvl.PrepareForSaving();
            Assert.AreEqual(0, lvl.Layers[0].Tiles.Count, "Level contains empty tiles");
        }

        [TestMethod]
        public void LayerAddTileTest()
        {
            Layer l = new Layer();
            l.AddTile(new Tile());
            l.AddTile(new Tile());
            Assert.AreEqual(1, l.Tiles.Count, "Layer added two tile on top of each other");
        }
    }
}
