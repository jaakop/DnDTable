using System.Drawing;
using System.Windows.Forms;

using GameEngine.Level;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// Form from where the game itself is to be played
    /// </summary>
    public partial class GameForm : Form
    {
        private Level level;

        /// <summary>
        /// New GameForm
        /// </summary>
        /// <param name="screen">Reference to a screen where the game is drawn to</param>
        public GameForm(Screen screen)
        {
            InitializeComponent();
            DoubleBuffered = true;
            
            Rectangle bounds = screen.Bounds;
            Bounds = bounds;
            
        }

        /// <summary>
        /// Handles GameForm paint event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            if(level != null)
                level.DrawLevel(e.Graphics, 60);
        }

        /// <summary>
        /// Load a level to the GameForm
        /// </summary>
        /// <param name="lvl">Level to load</param>
        /// <returns>True if succesfull</returns>
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
