using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDTable
{
    public partial class GameSelection : Form
    {
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

        public int GameID { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            GameID = ((Game)comboBox1.SelectedItem).GameId;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
    struct Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}
