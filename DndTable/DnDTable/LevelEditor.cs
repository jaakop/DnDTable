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

        Button newLevelButton;
        Button loadLevelButton;
        Button saveLevelButton;

        Editor.Camera cam;
        Level level;
        public LevelEditor()
        {
            InitializeComponent();
            Bounds = Screen.AllScreens[0].Bounds;
            AdjustSize();
            newLevelButton = InitializeButton(panel2, 1, "New Level", -65);
            saveLevelButton = InitializeButton(panel2, 2, "Save Level", -70);
            loadLevelButton = InitializeButton(panel2, 3, "Load Level", -75);

            panel2.Controls.Add(newLevelButton);
            panel2.Controls.Add(saveLevelButton);
            panel2.Controls.Add(loadLevelButton);

            cam = new Editor.Camera(gridW / 2, gridH / 2, 16, 9);
            level = new Level();
            Layer layer = new Layer();
            level.AddALayer(layer);
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
            panel1.Width = Width / 4 * 3;
            panel2.Width = Width / 4;
            panel1.Height = Height;
            panel2.Height = Height;
            panel2.Location = new Point(Width / 4 * 3, 0);
        }
    }
}
