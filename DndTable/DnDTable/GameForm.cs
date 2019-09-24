using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using GameEngine;
using GameEngine.Level;

namespace DnDTable
{
    public partial class GameForm : Form
    {
        Level level;
        public GameForm(Screen screen)
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            Rectangle bounds = screen.Bounds;
            Bounds = bounds;
            
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if(level != null)
                level.DrawLevel(e.Graphics, 60);
        }

        public bool LoadLevel(Level lvl)
        {
            level = lvl;
            try
            {
                foreach (Layer layer in level.Layers)
                {
                    foreach (Tile tile in layer.Tiles)
                    {
                        tile.LoadImage(level.Maps);
                    }
                }
                Invalidate();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
