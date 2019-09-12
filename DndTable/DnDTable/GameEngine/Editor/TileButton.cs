using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DnDTable.GameEngine.Editor
{
    class TileButton : Button
    {
        int id;
        
        public TileButton(int ImageId, Image image)
        {
            id = ImageId;
            BackgroundImage = image;
        }
        public int Id { get => id; }
    }
}
