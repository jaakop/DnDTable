using System;
using System.Data.SqlClient;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// Form, from which is possible to select a game
    /// </summary>
    public partial class GameSelection : Form
    {
        /// <summary>
        /// New GameSelection From
        /// </summary>
        public GameSelection()
        {
            InitializeComponent();

            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\jaakop\DnDTable\DndTable\DnDTable\DnDDataBase.mdf;Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Games", connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Game game = new Game();
                    game.GameId = int.Parse(reader["Id"].ToString());
                    game.Name = reader["Name"].ToString();
                    comboBox1.Items.Add(game);
                }
            }
            command.Dispose();
            connection.Close();
            comboBox1.DisplayMember = "Name";
        }

        /// <summary>
        /// *Handle Start button click
        /// </summary>
        /// <param name="sender">semder</param>
        /// <param name="e">event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            GameID = ((Game)comboBox1.SelectedItem).GameId;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// ID of the game
        /// </summary>
        public int GameID { get; set; }
    }

    /// <summary>
    /// Game struct to hold GameID and Name
    /// </summary>
    public struct Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
