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
    public partial class MainMenuFrom : Form
    {
        
        public MainMenuFrom()
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
            GameForm game = new GameForm(Screen.AllScreens[ScreenCom.SelectedIndex]);
            game.Show();
            GMForm gM = new GMForm(game, this);
            try
            {
                gM.Show();
                gM.Focus();
                Hide();
            }
            catch { }
        }

        private void LevelEditorButton_Click(object sender, EventArgs e)
        {
            Hide();
            LevelEditor editor = new LevelEditor();
            editor.FormClosed += delegate { Show(); };
            editor.ShowDialog();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
                if (ScreenCom.SelectedIndex == -1)
                    return;
            GameSelection gameSelection = new GameSelection();
            gameSelection.ShowDialog();
            if(gameSelection.DialogResult == DialogResult.OK)
            {

                GameForm game = new GameForm(Screen.AllScreens[ScreenCom.SelectedIndex]);
                game.Show();
                GMForm gM = new GMForm(game, this, gameSelection.GameID);
                try
                {
                    gM.Show();
                    gM.Focus();
                    Hide();
                }
                catch { }
            }
        }
    }
}
