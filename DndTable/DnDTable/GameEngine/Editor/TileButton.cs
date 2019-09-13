using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameEngine.Editor
{
    public class TileButton : Button
    {
        int tileId;
        int mapId;

        public TileButton(int ImageId, int MapId, Image image)
        {
            tileId = ImageId;
            mapId = MapId;
            BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public int TileId { get => tileId; }
        public int MapId { get => mapId; }
    }
}
