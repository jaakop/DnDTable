using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using GameEngine;
using GameEngine.Editor;
using GameEngine.Level;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    public partial class LevelEditor : Form
    {
        #region Class Variables
        private int gridW = 32;
        private int gridH = 18;
        private int tileSize = 75;

        private int selectedTileID;
        private int selectedMapID;

        private Button newLevelButton;
        private Button loadLevelButton;
        private Button saveLevelButton;

        private NumericUpDown layerSelection;
        private Button newLayerButton;
        private Button deleteLayerButton;

        private Button addMapButton;

        private CheckBox eraseSelection;

        private List<TileButton> buttons;

        private Camera cam;
        private Level level;

        private Tile selectedTile;

        private Image selectedImage;
        #endregion

        /// <summary>
        /// New LeverEditor
        /// </summary>
        public LevelEditor()
        {
            //Initialization
            InitializeComponent();
            Bounds = Screen.AllScreens[0].Bounds;
            AdjustSize();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            panel1.Paint += Panel1_Paint;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            cam = new Camera(5, 3, 14, 10)
            {
                FovX = (panel1.Width - panel1.Width / 20) / 75,
                FovY = (panel1.Height - panel1.Height / 20) / 75
            };
            level = new Level();

            //set scrollbar sizes
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


            //Create tile buttons
            buttons = new List<TileButton>();

            for (int i = 0; i < level.Maps.Count; i++)
            {
                List<Image> images = level.Maps[i].SliceTileMap();
                for (int j = 0; j < images.Count; j++)
                {
                    TileButton tileButton = new TileButton(j, i, images[j])
                    {
                        Width = 40,
                        Height = 40
                    };
                    tileButton.Click += TileSelection;
                    buttons.Add(tileButton);
                }
            }
            SetTileButtons();

            //Add eraseselection
            eraseSelection = new CheckBox()
            {
                Text = "Erase",
                Location = new Point(10, panel3.Location.Y - 25)
            };
            panel2.Controls.Add(eraseSelection);

            //Add layer controls
            layerSelection = new NumericUpDown()
            {
                Location = new Point(25, newLevelButton.Height * 2),
                Width = 50,
                Value = 0,
                Minimum = 0,
                Maximum = level.Layers.Count
            };
            newLayerButton = new Button()
            {
                Location = new Point(100, newLevelButton.Height * 2),
                Text = "Add a layer",
                Width = 100
            };
            deleteLayerButton = new Button()
            {
                Location = new Point(200, newLevelButton.Height * 2),
                Text = "Remove a layer",
                Width = 100
            };

            newLayerButton.Click += LayerButtonClick;
            deleteLayerButton.Click += LayerButtonClick;
            panel2.Controls.Add(layerSelection);
            panel2.Controls.Add(newLayerButton);
            panel2.Controls.Add(deleteLayerButton);

            //Add tileMap controls
            addMapButton = new Button()
            {
                Width = 100,
                Height = 25,
                Text = "Add new TileMap",
            };
            addMapButton.Location = new Point(eraseSelection.Location.X + eraseSelection.Width, panel3.Location.Y - 30);
            addMapButton.Click += AddTileMapButtonClick;
            panel2.Controls.Add(addMapButton);
            
            //Add default objects
            AddNewLayer();
            DrawMiniMap();

            panel1.Invalidate();
        }

        /// <summary>
        /// Handle AddTileMapButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void AddTileMapButtonClick(object sender, EventArgs e)
        {
            AddTileForm tileForm = new AddTileForm(this);
            tileForm.ShowDialog();
        }

        /// <summary>
        /// Handle LayerButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void LayerButtonClick(object sender, EventArgs e)
        {
            if (sender == newLayerButton)
            {
                AddNewLayer();
            }
            else if (sender == deleteLayerButton)
            {
                if (level.Layers.Count > 1)
                {
                    level.Layers.RemoveAt((int)layerSelection.Value - 1);
                    panel1.Invalidate();
                }
                else
                {
                    MessageBox.Show("You can't delete your only layer");
                }
            }
            layerSelection.Maximum = level.Layers.Count;
        }

        /// <summary>
        /// Selects a tile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileSelection(object sender, EventArgs e)
        {
            TileButton button = (TileButton)sender;
            selectedImage = level.Maps[button.MapId].SliceTileMap()[button.TileId];
            selectedTileID = button.TileId;
            selectedMapID = button.MapId;
        }

        /// <summary>
        /// Handles the button presses
        /// </summary>
        /// <param name="sender">Button, which was pressed</param>
        /// <param name="e"></param>
        private void HandleButtonClick(object sender, EventArgs e)
        {
            if (sender == newLevelButton)
            {
                level = new Level();
                AddNewLayer();

                DrawMiniMap();

                panel1.Invalidate();

            }

            else if (sender == loadLevelButton)
            {
                OpenFileDialog openFile = new OpenFileDialog();

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Level newLevel = FileHandler.LoadLevel(openFile.FileName);
                    level = newLevel;

                    for (int i = 0; i < level.Maps.Count; i++)
                    {
                        TileMap map = level.Maps[i];

                        List<Image> images = map.SliceTileMap();
                        for (int j = 0; j < images.Count; j++)
                        {
                            TileButton tileButton = new TileButton(j, i, images[j])
                            {
                                Width = 40,
                                Height = 40
                            };
                            tileButton.Click += TileSelection;
                            buttons.Add(tileButton);
                        }
                    }

                    SetTileButtons();

                    foreach (Layer layer in level.Layers)
                    {
                        foreach (Tile tile in layer.Tiles)
                        {
                            tile.LoadImage(level.Maps);
                        }
                    }

                    for (int i = 0; i < gridW; i++)
                    {
                        for (int j = 0; j < gridH; j++)
                        {
                            foreach (Layer layer in level.Layers)
                            {
                                Tile newTile = null;
                                foreach (Tile tile in layer.Tiles)
                                {
                                    if (tile.X == i && tile.Y == j)
                                    {
                                        newTile = tile;
                                    }
                                }
                                if (newTile != null)
                                {
                                    continue;
                                }

                                newTile = new Tile(i, j);
                                layer.AddTile(newTile);
                            }


                        }
                    }

                    layerSelection.Maximum = level.Layers.Count;

                    DrawMiniMap();

                    panel1.Invalidate();

                }
            }

            else if (sender == saveLevelButton)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileHandler.SaveLevel(level, saveFile.FileName);
                }
            }
        }

        /// <summary>
        /// Handle panelPaint event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            BufferedGraphicsContext dc = new BufferedGraphicsContext();
            BufferedGraphics backbuffer = dc.Allocate(g, new Rectangle(new Point(0, 0), g.VisibleClipBounds.Size.ToSize()));
            backbuffer.Graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, g.VisibleClipBounds.Size.ToSize().Width, g.VisibleClipBounds.Size.ToSize().Height));
            foreach (Layer layer in level.Layers)
            {
                foreach (Tile tile in layer.Tiles)
                {
                    if (tile.X < cam.Location().X + cam.FovX / 2 &
                        tile.X > cam.Location().X - cam.FovX / 2 &
                        tile.Y < cam.Location().Y + cam.FovY / 2 &
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
        /// Handle Resizing of the editor
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void LevelEditor_Resize(object sender, EventArgs e)
        {
            AdjustSize();
            SetTileButtons();
            if (panel2 == null || newLevelButton == null || saveLevelButton == null || loadLevelButton == null)
            {
                return;
            }

            if (panel2.Width < newLevelButton.Width + saveLevelButton.Width + 100)
            {
                saveLevelButton.Location = new Point(panel2.Width / 2 - saveLevelButton.Width / 2, saveLevelButton.Height * 2 + saveLevelButton.Height / 2);
                loadLevelButton.Location = new Point(panel2.Width / 2 - loadLevelButton.Width / 2, loadLevelButton.Height + loadLevelButton.Height / 2);
                newLevelButton.Location = new Point(panel2.Width / 2 - newLevelButton.Width / 2, newLevelButton.Height / 2);

                layerSelection.Location = new Point(layerSelection.Location.X, 4 * saveLevelButton.Height);
                newLayerButton.Location = new Point(newLayerButton.Location.X, 4 * saveLevelButton.Height);
                deleteLayerButton.Location = new Point(deleteLayerButton.Location.X, 4 * saveLevelButton.Height);
            }
            else if (panel2.Width < newLevelButton.Width + saveLevelButton.Width + loadLevelButton.Width + 25)
            {
                saveLevelButton.Location = new Point(panel2.Width / 2 - saveLevelButton.Width / 2, saveLevelButton.Height + saveLevelButton.Height / 3 * 2);
                loadLevelButton.Location = new Point(panel2.Width - loadLevelButton.Width / 2 - 100, loadLevelButton.Height / 2);
                newLevelButton.Location = new Point(panel2.Width / 2 - newLevelButton.Width / 2 - 60, newLevelButton.Height / 2);

                layerSelection.Location = new Point(layerSelection.Location.X, 3 * saveLevelButton.Height);
                newLayerButton.Location = new Point(newLayerButton.Location.X, 3 * saveLevelButton.Height);
                deleteLayerButton.Location = new Point(deleteLayerButton.Location.X, 3 * saveLevelButton.Height);
            }
            else
            {
                saveLevelButton.Location = new Point(panel2.Width / 3 * 2 - saveLevelButton.Width / 2 - 70, saveLevelButton.Height / 2);
                loadLevelButton.Location = new Point(panel2.Width - loadLevelButton.Width / 2 - 75, loadLevelButton.Height / 2);
                newLevelButton.Location = new Point(panel2.Width / 3 - newLevelButton.Width / 2 - 65, newLevelButton.Height / 2);

                layerSelection.Location = new Point(layerSelection.Location.X, 2 * saveLevelButton.Height);
                newLayerButton.Location = new Point(newLayerButton.Location.X, 2 * saveLevelButton.Height);
                deleteLayerButton.Location = new Point(deleteLayerButton.Location.X, 2 * saveLevelButton.Height);
            }
            cam.FovX = (panel1.Width - panel1.Width / 10) / tileSize;
            cam.FovY = (panel1.Height - panel1.Height / 8) / tileSize;
            hScrollBar1.Maximum = gridW + (panel1.Width / tileSize);
            vScrollBar1.Maximum = gridH + (panel1.Height / tileSize);

            panel2.Invalidate();
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
            if (eraseSelection != null)
            {
                eraseSelection.Location = new Point(10, panel3.Location.Y - 25);
            }
        }

        /// <summary>
        /// Handle mouse movement on the panel
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = new Point(e.X, e.Y);
            if (level == null)
            {
                return;
            }

            foreach (Tile tile in level.Layers[(int)layerSelection.Value].Tiles)
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

            GC.Collect();
        }

        /// <summary>
        /// Handle mouseclick on the panel
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedTile != null)
            {
                if (selectedImage == null)
                {
                    MessageBox.Show("You haven't selected a tile");
                    return;
                }
                if (eraseSelection.Checked)
                {
                    selectedTile.Erase();
                    panel1.Invalidate();
                }
                else
                {
                    Tile newTile = new Tile(selectedTile.X, selectedTile.Y, selectedTileID, selectedMapID, (Bitmap)selectedImage);
                    level.Layers[(int)layerSelection.Value].AddTile(newTile);
                    selectedTile = newTile;

                    panel1.Invalidate();

                }

            }

            DrawMiniMap();
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
            }
            else if (sender == vScrollBar1)
            {
                cam.Move(cam.Location().X, vScrollBar1.Value);
            }
            panel1.Invalidate();
            System.GC.Collect();
        }

        /// <summary>
        /// Handle tile selection scrollbar scrolling
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void TileScollBarScroll(object sender, ScrollEventArgs e)
        {
            SetTileButtons();
        }

        /// <summary>
        /// Add a new tilemap
        /// </summary>
        /// <param name="path">Path to the tilemap</param>
        /// <param name="size">Size of the tiles</param>
        public void AddTileMap(string path, int size)
        {
            TileMap map = new TileMap(path, size);

            List<Image> images = map.SliceTileMap();
            for (int j = 0; j < images.Count; j++)
            {
                TileButton tileButton = new TileButton(j, level.Maps.Count, images[j])
                {
                    Width = 40,
                    Height = 40
                };
                tileButton.Click += TileSelection;
                buttons.Add(tileButton);
            }
            level.AddAMap(map);
            SetTileButtons();
        }

        /// <summary>
        /// Add a new layer to the level
        /// </summary>
        private void AddNewLayer()
        {
            Layer layer = new Layer();
            for (int i = 0; i < gridW; i++)
            {
                for (int j = 0; j < gridH; j++)
                {
                    layer.AddTile(new Tile(i, j));
                }
            }
            level.AddALayer(layer);
        }

        /// <summary>
        /// Draw a minimap of the level
        /// </summary>
        void DrawMiniMap()
        {
            Graphics minimapG = panel2.CreateGraphics();
            minimapG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            minimapG.FillRectangle(new Pen(panel2.BackColor).Brush, 15, eraseSelection.Location.Y - (gridW * 6 / 2), gridW * 5, gridH * 5);
            minimapG.DrawImage(Minimap.DrawMinimap(level, gridW, gridH, tileSize, tileSize), 15, eraseSelection.Location.Y - (gridW * 6 / 2), gridW * 5, gridH * 5);
            minimapG.DrawRectangle(Pens.Black, 10, eraseSelection.Location.Y - (gridW * 6 / 2) - 5, gridW * 5 + 5, gridH * 5 + 5);
        }

        /// <summary>
        /// Initializes a default button
        /// </summary>
        /// <param name="panel">Panel, where the button belongs to</param>
        /// <param name="position">Button position</param>
        /// <param name="buttonText">Text of the button</param>
        /// <param name="offSet">Offset for the button position</param>
        /// <returns></returns>
        Button InitializeButton(Panel panel, int position, string buttonText, int offSet)
        {
            Button button = new Button
            {
                Text = buttonText,
                Font = new Font(FontFamily.GenericMonospace, 10),
                Width = 100,
                Height = 50
            };
            button.Click += HandleButtonClick;
            button.Location = new Point(panel.Width / 3 * position - button.Width / 2 + offSet, button.Height / 2);
            return button;
        }

        /// <summary>
        /// Set tile buttons
        /// </summary>
        void SetTileButtons()
        {
            if (level == null)
            {
                return;
            }

            int j = 0;
            int tileId = 0;
            for (int i = 0; i < level.Maps.Count; i++)
            {
                for (; ; j++)
                {
                    if (tileId >= buttons.Count)
                    {
                        break;
                    }

                    for (int k = 0; k < (panel3.Width - vScrollBar2.Width) / 40; k++)
                    {
                        if (tileId >= buttons.Count)
                        {
                            break;
                        }

                        buttons[tileId].Location = new Point(k * 40, j * 40 - vScrollBar2.Value);
                        panel3.Controls.Add(buttons[tileId]);
                        tileId++;
                    }
                }
                j += 2;
            }
            vScrollBar2.Maximum = j * 30;
        }
    }
}
