using System;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// Form, which opens when user wants to add a new tilemap to the app
    /// </summary>
    public partial class AddTileForm : Form
    {
        private LevelEditor levelEditor;
        private string filePath;

        /// <summary>
        /// New TileForm
        /// </summary>
        /// <param name="editor">Reference to the tilemap editor</param>
        public AddTileForm(LevelEditor editor)
        {
            InitializeComponent();
            levelEditor = editor;
            HeightBox.Enabled = false;
        }

        /// <summary>
        /// Handle text change in WidthBox textbox
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            HeightBox.Text = WidthBox.Text;
        }

        /// <summary>
        /// Handle OpenFileButton click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Images (*.png)|*png";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                FilePath.Text = filePath;
            }
        }

        /// <summary>
        /// Handle Submit button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(WidthBox.Text, out int ree))
            {
                MessageBox.Show("Size is not valid");
                return;
            }

            levelEditor.AddTileMap(filePath, int.Parse(WidthBox.Text));
            Close();
        }
    }
}
