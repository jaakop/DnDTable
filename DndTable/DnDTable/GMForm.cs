using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

using GameEngine.Level;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// GMForm from which the game is controlled
    /// </summary>
    public partial class GMForm : Form
    {
        private GameForm gameForm;
        private MainMenuFrom mainMenu;

        private int gameID = -1;
        private int noteId = 0;

        private List<Note> notes;

        private string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\DnDDataBase.mdf;Integrated Security=True";

        /// <summary>
        /// New GMForm
        /// </summary>
        /// <param name="game">GameForm reference</param>
        /// <param name="main">MainForm reference</param>
        public GMForm(GameForm game, MainMenuFrom main)
        {
            InitializeComponent();
            notes = new List<Note>();
            MessageIDText.Text = "0/0";
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
        /// <param name="game">GameForm reference</param>
        /// <param name="main">MainForm reference</param>
        /// <param name="GameID">GameId for excisting game</param>
        public GMForm(GameForm game, MainMenuFrom main, int GameID)
        {

            InitializeComponent();
            notes = new List<Note>();
            MessageIDText.Text = "0/0";
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
        /// BrowseButton click evemt
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
        /// LoadLevelButton click evemt
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
        /// DrawLevelButton click evemt
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
        /// AddNoteButton click evemt
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            if (NoteInputTextBox.Text.Length > 200)
            {
                MessageBox.Show("Note is too long");
                return;
            }

            else if(NoteInputTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Don't even try...");
                return;
            }

            SqlConnection connection = new SqlConnection(conString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Notes (Content, GameID) VALUES (@content, @gameId)", connection);
            command.Parameters.AddWithValue("@content", NoteInputTextBox.Text);
            command.Parameters.AddWithValue("@gameId", gameID);

            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();

            AddANote(NoteInputTextBox.Text);
            NoteInputTextBox.Text = "";
        }

        /// <summary>
        /// NoteUpButton click evemt
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void NoteUpButton_Click(object sender, EventArgs e)
        {
            if(noteId + 1 < notes.Count)
                noteId++;
            NoteTextBox.Text = notes[noteId].Name;
            MessageIDText.Text = (noteId + 1) + "/" + notes.Count;
        }

        /// <summary>
        /// NoteDownButto click evemt
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void NoteDownButton_Click(object sender, EventArgs e)
        {
            if (noteId - 1 >= 0)
                noteId--;
            NoteTextBox.Text = notes[noteId].Name;
            MessageIDText.Text = (noteId + 1) + "/" + notes.Count;
        }

        /// <summary>
        /// Add a note
        /// </summary>
        /// <param name="txt">Note content</param>
        private void AddANote(string txt)
        {
            Note note = new Note();
            note.Id = notes.Count;
            noteId = notes.Count;
            note.Name = txt;
            notes.Add(note);
            NoteTextBox.Text = note.Name;

            MessageIDText.Text = (noteId + 1) + "/" + notes.Count;
        }
    }

    /// <summary>
    /// Note struct to hold not info
    /// </summary>
    public struct Note
    {
        /// <summary>
        /// Note Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Note Content
        /// </summary>
        public string Name { get; set; }
    }
}
