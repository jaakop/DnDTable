using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using GameEngine.Level;

namespace DnDTable
{
    public partial class GMForm : Form
    {
        GameForm gameForm;
        MainMenuFrom mainMenu;

        int gameID = -1;

        List<Note> notes;

        int noteId = 0;

        string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\DnDDataBase.mdf;Integrated Security=True";

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

        private void NoteUpButton_Click(object sender, EventArgs e)
        {
            if(noteId + 1 < notes.Count)
                noteId++;
            NoteTextBox.Text = notes[noteId].Name;
            MessageIDText.Text = (noteId + 1) + "/" + notes.Count;
        }

        private void NoteDownButton_Click(object sender, EventArgs e)
        {
            if (noteId - 1 >= 0)
                noteId--;
            NoteTextBox.Text = notes[noteId].Name;
            MessageIDText.Text = (noteId + 1) + "/" + notes.Count;
        }
    }
    struct Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
