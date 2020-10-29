using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

using GameEngine.Level;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// GMform where the game is controlled from
    /// </summary>
    public partial class GMForm : Form
    {
        private GameForm gameForm;
        private MainMenuFrom mainMenu;

        private int gameID = -1;

        private string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\jaakop\DnDTable\DndTable\DnDTable\DnDDataBase.mdf;Integrated Security=True";

        /// <summary>
        /// New GmForm
        /// </summary>
        /// <param name="game">Game to draw levels to</param>
        /// <param name="main">Reference to mainmenu form</param>
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

            NameForm nameForm = new NameForm();
            nameForm.ShowDialog();
            if(nameForm.DialogResult == DialogResult.OK)
            {
                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Games (Name) VALUES (@gameName); SELECT SCOPE_IDENTITY()", connection);
                command.Parameters.AddWithValue("@gameName", nameForm.NewName);

                gameID = Convert.ToInt32(command.ExecuteScalar());
                
                command.Dispose();
                connection.Close();
            }
            else
            {
                Show();
                Close();
            }

        }

        /// <summary>
        /// New GMForm
        /// </summary>
        /// <param name="game">Game to draw levels to</param>
        /// <param name="main">Reference to mainmenu form</param>
        /// <param name="GameID">GameId for an existing game</param>
        public GMForm(GameForm game, MainMenuFrom main, int GameID)
        {

            InitializeComponent();
            gameForm = game;
            mainMenu = main;
            gameID = GameID;
            FormClosed += delegate
            {
                gameForm.Close();
                main.Show();
            };

            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT Path FROM Levels WHERE GameID = @gameId", connection);
            command.Parameters.AddWithValue("@gameId", gameID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    try
                    {
                    Level lvl = FileHandler.LoadLevel(reader["Path"].ToString());
                    lvl.Name = (levelCombo.Items.Count + 1).ToString();
                    levelCombo.Items.Add(lvl);
                    levelCombo.DisplayMember = "Name";
                    }
                    catch { }
                }
            }

            command = new SqlCommand("SELECT Content FROM Notes WHERE GameID = @gameId", connection);
            command.Parameters.AddWithValue("@gameId", gameID);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    AddANote(reader["Content"].ToString());
                }
            }

            command.Dispose();
            connection.Close();
        }

        /// <summary>
        /// Handl BrowseButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                levelPath.Text = openFile.FileName;
            }
        }

        /// <summary>
        /// Handl LoadLevelButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void LoadLevelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Level lvl = FileHandler.LoadLevel(levelPath.Text);
                lvl.Name = (levelCombo.Items.Count + 1).ToString();
                levelCombo.Items.Add(lvl);
                levelCombo.DisplayMember = "Name";

                SqlConnection connection = new SqlConnection(conString);
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Levels (Path, GameID) VALUES (@path, @gameId)", connection);
                command.Parameters.AddWithValue("@path", levelPath.Text);
                command.Parameters.AddWithValue("@gameId", gameID);

                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                levelPath.Text = "";
            }
            catch
            {
                MessageBox.Show("Something went wrong when loading the level");
            }
        }

        /// <summary>
        /// Handl DrawLevelButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
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

        /// <summary>
        /// Handl AddNoteButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            if (NoteTextBox.Text.Length > 200)
            {
                MessageBox.Show("Note is too long");
                return;
            }

            else if(NoteTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Don't even try...");
                return;
            }

            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Notes (Content, GameID) VALUES (@content, @gameId)", connection);
            command.Parameters.AddWithValue("@content", NoteTextBox.Text);
            command.Parameters.AddWithValue("@gameId", gameID);

            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            AddANote(NoteTextBox.Text);
            NoteTextBox.Text = "";
            
        }

        /// <summary>
        /// Adds a note to database
        /// </summary>
        /// <param name="txt">Note content</param>
        private void AddANote(string txt)
        {
            Label note = new Label();
            note.MaximumSize = new Size(NoteBox.Width - vScrollBar1.Width - 10, 0);
            note.Text = txt;
            note.Font = new Font(note.Font.FontFamily, 10, note.Font.Style);
            note.AutoSize = true;
            note.BorderStyle = BorderStyle.FixedSingle;
            note.Location = new Point(5, NoteBox.Height - note.Height);
            NoteBox.Controls.Add(note);
            for (int i = 0; i < NoteBox.Controls.Count; i++)
            {
                NoteBox.Controls[i].Location = new Point(NoteBox.Controls[i].Location.X, NoteBox.Controls[i].Location.Y - note.Height - 10);
            }
            NoteBox.Invalidate();
            
            for (int i = 0; i < NoteBox.Controls.Count; i++)
            {
                vScrollBar1.Maximum += NoteBox.Controls[i].Height;
            }
            vScrollBar1.Value = vScrollBar1.Maximum;
        }

        /// <summary>
        /// Handle notes scrollbar scrolling
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            for (int i = 0; i < NoteBox.Controls.Count; i++)
            {
                NoteBox.Controls[i].Location = new Point(NoteBox.Controls[i].Location.X, (vScrollBar1.Value * -1)- NoteBox.Controls[i].Height);
            }
        }
    }
}
