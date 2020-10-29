using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// GameSelection form
    /// </summary>
    public partial class GameSelection : Form
    {
        /// <summary>
        /// New GameSelection form
        /// </summary>
        public GameSelection()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() +@"\DnDDataBase.mdf;Integrated Security=True");
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
        /// OK button click event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            GameID = ((Game)comboBox1.SelectedItem).GameId;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Game Id
        /// </summary>
        public int GameID { get; set; }

    }

    /// <summary>
    /// Game struct to hold Game data
    /// </summary>
    public struct Game
    {
        /// <summary>
        /// Game id
        /// </summary>
        public int GameId { get; set; }
        /// <summary>
        /// Game name
        /// </summary>
        public string Name { get; set; }
    }
}
