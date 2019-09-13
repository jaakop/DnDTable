using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameEngine;
using GameEngine.Level;
using GameEngine.Editor;

namespace DnDTable
{
    public partial class LevelEditor : Form
    {
        #region Class Variables
        int gridW = 32;
        int gridH = 18;
        int tileSize = 75;

        Button newLevelButton;
        Button loadLevelButton;
        Button saveLevelButton;

        List<TileButton> buttons;

        Camera cam;
        Level level;

        Tile oldTile;
        Tile selectedTile;

        Image selectedImage;
        #endregion

        public LevelEditor()
        {
            InitializeComponent();
            Bounds = Screen.AllScreens[0].Bounds;
            AdjustSize();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);

            panel1.Paint += Panel1_Paint;

            hScrollBar1.Maximum = gridW + 5;
            hScrollBar1.Minimum = 5;
            vScrollBar1.Maximum = gridH + 5;
            vScrollBar1.Minimum = 3;

            //Button initialization
            newLevelButton = InitializeButton(panel2, 1, "New Level", -65);
            saveLevelButton = InitializeButton(panel2, 2, "Save Level", -70);
            loadLevelButton = InitializeButton(panel2, 3, "Load Level", -75);

            //Buttons added to the panel
            panel2.Controls.Add(newLevelButton);
            panel2.Controls.Add(saveLevelButton);
            panel2.Controls.Add(loadLevelButton);

            cam = new Camera(5, 3, 14, 10);
            level = new Level();
            Layer layer = new Layer();
            level.AddALayer(layer);

            for(int i = 0; i < gridW; i++)
            {
                for(int j = 0; j < gridH; j++)
                {
                    level.Layers[0].AddTile(new Tile(i, j));
                }
            }

            level.AddAMap(new TileMap("C:/Users/Jaakko/Desktop/terrain_atlas.png", 32));
            for (int i = 0; i < level.Maps.Count; i++)
            {
                List<Image> images = level.Maps[i].SliceTileMap();
                buttons = new List<TileButton>();
                for (int j = 0; j < images.Count; j++)
                {
                    TileButton tileButton = new TileButton(j, i, images[j]);
                    tileButton.Width = 40;
                    tileButton.Height = 40;
                    tileButton.Click += TileSelection;
                    buttons.Add(tileButton);
                }
            }
            SetButtons();
            panel1.Invalidate();
        }

        void SetButtons()
        {
            if (level == null)
                return;
            for (int i = 0; i < level.Maps.Count; i++)
            {
                int tileId = 0;
                int l = 0;
                for (; ; l++)
                {
                    if (tileId >= buttons.Count)
                        break;
                    for (int k = 0; k < (panel3.Width - vScrollBar2.Width) / 40; k++)
                    {
                        if (tileId >= buttons.Count)
                            break;
                        buttons[tileId].Location = new Point(k * 40, l * 40 - vScrollBar2.Value);
                        panel3.Controls.Add(buttons[tileId]);
                        tileId++;
                    }
                }
                vScrollBar2.Maximum = l * 30;
            }
        }

        private void TileSelection(object sender, EventArgs e)
        {
            TileButton button = (TileButton)sender;
            selectedImage = level.Maps[button.MapId].SliceTileMap()[button.TileId];
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            BufferedGraphicsContext dc = new BufferedGraphicsContext();
            BufferedGraphics backbuffer = dc.Allocate(g, new Rectangle(new Point(0, 0), g.VisibleClipBounds.Size.ToSize()));
            backbuffer.Graphics.FillRectangle(Brushes.White, new Rectangle(0,0, g.VisibleClipBounds.Size.ToSize().Width, g.VisibleClipBounds.Size.ToSize().Height));
            foreach(Layer layer in level.Layers)
            {
                foreach(Tile tile in layer.Tiles)
                {
                    if (tile.X < cam.Location().X + cam.FovX / 2&
                        tile.X > cam.Location().X - cam.FovX / 2&
                        tile.Y < cam.Location().Y + cam.FovY / 2&
                        tile.Y > cam.Location().Y - cam.FovY / 2)
                    {
                        tile.DrawTile(backbuffer.Graphics, tile.X - cam.Location().X + cam.FovX / 2, tile.Y - cam.Location().Y + cam.FovY / 2, tileSize, 0);
                        tile.DrawWireFrame(backbuffer.Graphics, tile.X - cam.Location().X + cam.FovX / 2, tile.Y - cam.Location().Y + cam.FovY / 2, tileSize, 0);
                    }
                }
            }
            backbuffer.Render(g);
        }

        /// <summary>
        /// Initializes a button
        /// </summary>
        /// <param name="panel">Panel, where the button belongs to</param>
        /// <param name="position">Button position</param>
        /// <param name="buttonText">Text of the button</param>
        /// <param name="offSet">Offset for the button position</param>
        /// <returns></returns>
        Button InitializeButton(Panel panel, int position, string buttonText, int offSet)
        {

            Button button = new Button();
            button.Text = buttonText;
            button.Font = new Font(FontFamily.GenericMonospace, 10);
            button.Click += HandleButtonClick;
            button.Width = 100;
            button.Height = 50;
            button.Location = new Point(panel.Width / 3 * position - button.Width / 2 + offSet, button.Height / 2);
            return button;
        }

        /// <summary>
        /// Handles the button presses
        /// </summary>
        /// <param name="sender">Button, which was pressed</param>
        /// <param name="e"></param>
        private void HandleButtonClick(object sender, EventArgs e)
        {
            if(sender == newLevelButton)
            {
                MessageBox.Show(new NotImplementedException().ToString());
            }
            else if(sender == loadLevelButton)
            {
                MessageBox.Show(new NotImplementedException().ToString());
            }
            else if(sender == saveLevelButton)
            {
                MessageBox.Show(new NotImplementedException().ToString());
            }
        }

        private void LevelEditor_Resize(object sender, EventArgs e)
        {
            AdjustSize();
            SetButtons();
            if (panel2 == null || newLevelButton == null || saveLevelButton == null || loadLevelButton == null)
                return;
            if (panel2.Width < newLevelButton.Width + saveLevelButton.Width + 100)
            {
                saveLevelButton.Location = new Point(panel2.Width / 2 - saveLevelButton.Width / 2, saveLevelButton.Height * 2 + saveLevelButton.Height / 2);
                loadLevelButton.Location = new Point(panel2.Width / 2 - loadLevelButton.Width / 2, loadLevelButton.Height + loadLevelButton.Height/2);
                newLevelButton.Location = new Point(panel2.Width / 2 - newLevelButton.Width / 2, newLevelButton.Height / 2);
            }
            else if (panel2.Width < newLevelButton.Width + saveLevelButton.Width + loadLevelButton.Width + 25)
            {
                saveLevelButton.Location = new Point(panel2.Width/2 - saveLevelButton.Width/2, saveLevelButton.Height + saveLevelButton.Height / 3 * 2);
                loadLevelButton.Location = new Point(panel2.Width - loadLevelButton.Width / 2 - 100, loadLevelButton.Height / 2);
                newLevelButton.Location = new Point(panel2.Width / 2 - newLevelButton.Width / 2 - 60, newLevelButton.Height / 2);
            }
            else
            {
                saveLevelButton.Location = new Point(panel2.Width / 3 * 2 - saveLevelButton.Width / 2 - 70, saveLevelButton.Height / 2);
                loadLevelButton.Location = new Point(panel2.Width - loadLevelButton.Width / 2 - 75, loadLevelButton.Height / 2);
                newLevelButton.Location = new Point(panel2.Width / 3 - newLevelButton.Width / 2 - 65, newLevelButton.Height / 2);
            }
        }

        /// <summary>
        /// Adjusts the size of the panels and position of buttons
        /// </summary>
        void AdjustSize()
        {
            panel1.Width = Width / 4 * 3 - vScrollBar1.Width;
            panel2.Width = Width / 4;
            panel1.Height = Height - hScrollBar1.Height * 3;
            panel2.Height = Height;
            panel2.Location = new Point(Width / 4 * 3, 0);
            panel3.Width = panel2.Width - vScrollBar2.Width;
            panel3.Height = panel2.Height / 3;
            panel3.Location = new Point(0, panel2.Height - panel3.Height - 50);
        }

        /// <summary>
        /// Where the camera movement is handeled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveCamera(object sender, ScrollEventArgs e)
        {
            if (sender == hScrollBar1)
            {
                cam.Move(hScrollBar1.Value, cam.Location().Y);
            }else if(sender == vScrollBar1)
            {
                cam.Move(cam.Location().X, vScrollBar1.Value);
            }
            panel1.Invalidate();
            System.GC.Collect();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = new Point(e.X, e.Y);
            if (level == null)
                return;

            foreach (Layer layer in level.Layers)
            {
                foreach (Tile tile in layer.Tiles)
                {
                    int tileX = tile.X * tileSize - cam.Location().X * tileSize + cam.FovX / 2 * tileSize;
                    int tileY = tile.Y * tileSize - cam.Location().Y * tileSize + cam.FovY / 2 * tileSize;

                    if (pos.X > tileX && pos.X < tileX + tileSize)
                    {
                        if (pos.Y > tileY && pos.Y < tileY + tileSize)
                        {

                            if (tile.X < cam.Location().X + cam.FovX / 2 &
                                tile.X > cam.Location().X - cam.FovX / 2 &
                                tile.Y < cam.Location().Y + cam.FovY / 2 &
                                tile.Y > cam.Location().Y - cam.FovY / 2)
                            {
                                selectedTile = tile;
                            }
                        }
                    }
                }
            }
            if (oldTile != null && selectedTile != null && oldTile.X == selectedTile.X && oldTile.Y == selectedTile.Y )
                return;

            if (oldTile != null)
                oldTile.HighLight(panel1.CreateGraphics(), oldTile.X - cam.Location().X + cam.FovX / 2, oldTile.Y - cam.Location().Y + cam.FovY / 2, tileSize, false);

            if (selectedTile == null)
                return;
            selectedTile.HighLight(panel1.CreateGraphics(), selectedTile.X - cam.Location().X + cam.FovX / 2, selectedTile.Y - cam.Location().Y + cam.FovY / 2, tileSize, true);

            oldTile = selectedTile
;
            GC.Collect();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && selectedTile != null)
            {
                if(selectedImage == null)
                {
                    MessageBox.Show("You haven't selected a tile");
                    return;
                }
                Tile newTile = new Tile(selectedTile.X, selectedTile.Y, (Bitmap)selectedImage);
                level.Layers[0].AddTile(newTile);
                selectedTile = newTile;
                oldTile = selectedTile;
                selectedTile.HighLight(panel1.CreateGraphics(), selectedTile.X - cam.Location().X + cam.FovX / 2, selectedTile.Y - cam.Location().Y + cam.FovY / 2, tileSize, true);
                panel1.Invalidate();
            }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            SetButtons();
        }
    }
}
