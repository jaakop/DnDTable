using System;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// MainMenu form
    /// </summary>
    public partial class MainMenuFrom : Form
    {
        /// <summary>
        /// New main menu
        /// </summary>
        public MainMenuFrom()
        {
            InitializeComponent();
            for(int i = 0; i < Screen.AllScreens.Length; i++)
            {
                ScreenCom.Items.Add(i + 1);
            }
        }

        /// <summary>
        /// Handle newGame button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
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

        /// <summary>
        /// Handle LevelEditor button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void LevelEditorButton_Click(object sender, EventArgs e)
        {
            Hide();
            LevelEditor editor = new LevelEditor();
            editor.FormClosed += delegate { Show(); };
            editor.ShowDialog();
        }

        /// <summary>
        /// Handle LoadGame button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
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
