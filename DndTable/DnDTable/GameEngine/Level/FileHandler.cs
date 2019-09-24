using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;

using Newtonsoft.Json;

namespace GameEngine.Level
{
    public class FileHandler
    {

        public static void SaveLevel(Level lvl, string path)
        {
            Level level = new Level();
            foreach(TileMap map in lvl.Maps)
            {
                level.AddAMap(map);
            }
            foreach(Layer layer in lvl.Layers)
            {
                Layer newLayer = new Layer();
                foreach(Tile tile in layer.Tiles)
                {
                    if (tile.Image != null)
                    {
                        Tile newTile = tile;
                        newTile.PrepareForSaving();
                        newLayer.AddTile(newTile);
                    }
                }
                level.AddALayer(newLayer);
            }
            JsonSerializer serializer = new JsonSerializer();
            using(StreamWriter wr = new StreamWriter(path))
            {
                using(JsonWriter writer = new JsonTextWriter(wr))
                {
                    serializer.Serialize(writer, level);
                }
            }
        }
        public static Level LoadLevel(string path)
        {
            Level level = JsonConvert.DeserializeObject<Level>(File.ReadAllText(path));
            return level;
        }
    }
}
