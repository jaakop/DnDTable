using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GameEngine.Level;

namespace DnDTable
{
    public partial class LevelEditor : Form
    {
        int gridW = 32;
        int gridH = 18;
        int tileSize = 75;

        Button newLevelButton;
        Button loadLevelButton;
        Button saveLevelButton;

        Editor.Camera cam;
        Level level;

        Tile oldTile;
        Tile selectedTile;
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

            

            newLevelButton = InitializeButton(panel2, 1, "New Level", -65);
            saveLevelButton = InitializeButton(panel2, 2, "Save Level", -70);
            loadLevelButton = InitializeButton(panel2, 3, "Load Level", -75);

            panel2.Controls.Add(newLevelButton);
            panel2.Controls.Add(saveLevelButton);
            panel2.Controls.Add(loadLevelButton);

            cam = new Editor.Camera(5, 3, 14, 10);
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
            level.Layers[0].AddTile(new Tile(gridW - 1, gridH - 1, Properties.Resources.download));
            panel1.Invalidate();
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

        void AdjustSize()
        {
            panel1.Width = Width / 4 * 3 - vScrollBar1.Width;
            panel2.Width = Width / 4;
            panel1.Height = Height - hScrollBar1.Height * 3;
            panel2.Height = Height;
            panel2.Location = new Point(Width / 4 * 3, 0);
        }

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
            //panel1.CreateGraphics().DrawRectangle(Pens.Red, new Rectangle(pos.X - tileSize/2, pos.Y - tileSize / 2, tileSize, tileSize));

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
                            Console.WriteLine(tile.X + "\t" + tile.Y);

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
                Tile newTile = new Tile(selectedTile.X, selectedTile.Y, Properties.Resources.download);
                level.Layers[0].AddTile(newTile);
                selectedTile = newTile;
                oldTile = selectedTile;
                selectedTile.HighLight(panel1.CreateGraphics(), selectedTile.X - cam.Location().X + cam.FovX / 2, selectedTile.Y - cam.Location().Y + cam.FovY / 2, tileSize, true);
            }
        }
    }
}
