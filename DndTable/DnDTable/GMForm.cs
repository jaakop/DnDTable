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

namespace DnDTable
{
    public partial class GMForm : Form
    {
        GameForm game;
        public GMForm()
        {
            InitializeComponent();
            for(int i = 0; i < Screen.AllScreens.Length; i++)
            {
                ScreenCom.Items.Add(i + 1);
            }
        }

        private void NewGameClick(object sender, EventArgs e)
        {
            if (ScreenCom.SelectedIndex == -1)
                return;
            game = new GameForm(Screen.AllScreens[ScreenCom.SelectedIndex]);
            game.Show();
            Focus();
            Width = 1400;
            Height = 800;
            CenterToScreen();
            Controls.Clear();
        }

        private void LevelEditorButton_Click(object sender, EventArgs e)
        {
            Hide();
            LevelEditor editor = new LevelEditor();
            editor.FormClosed += delegate { Show(); };
            editor.ShowDialog();
        }
    }
}
