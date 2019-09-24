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
    public partial class GMForm : Form
    {
        GameForm gameForm;
        MainMenuFrom mainMenu;

        public GMForm(GameForm game, MainMenuFrom main)
        {
            InitializeComponent();
            gameForm = game;
            mainMenu = main;
            FormClosed += delegate
            {
                gameForm.Close();
                main.Show();
            };
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                levelPath.Text = openFile.FileName;
            }
        }

        private void LoadLevelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Level lvl = FileHandler.LoadLevel(levelPath.Text);
                lvl.Name = (levelCombo.Items.Count + 1).ToString();
                levelCombo.Items.Add(lvl);
                levelCombo.DisplayMember = "Name";
                levelPath.Text = "";
            }
            catch
            {
                MessageBox.Show("Something went wrong when loading the level");
            }
        }

        private void DrawLevelButton_Click(object sender, EventArgs e)
        {
            if (levelCombo.SelectedItem == null)
                return;
            bool returnValue = gameForm.LoadLevel((Level)levelCombo.SelectedItem);
            if (!returnValue)
            { 
                MessageBox.Show("Something went wrong with loading the level \n (Most probably you have moved the image file c:)");
            }
        }
    }
}
