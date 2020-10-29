using System.IO;

using Newtonsoft.Json;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace GameEngine.Level
{
    /// <summary>
    /// File Handler
    /// </summary>
    public class FileHandler
    {
        /// <summary>
        /// Save a level to a file
        /// </summary>
        /// <param name="lvl">Level to be saved</param>
        /// <param name="path">Path for the save file</param>
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

        /// <summary>
        /// Load a level from a file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>Level</returns>
        public static Level LoadLevel(string path)
        {
            Level level = JsonConvert.DeserializeObject<Level>(File.ReadAllText(path));
            return level;
        }
    }
}
