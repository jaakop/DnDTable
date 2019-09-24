using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDTable
{
    public partial class AddTileForm : Form
    {
        LevelEditor levelEditor;
        string filePath;
        public AddTileForm(LevelEditor editor)
        {
            InitializeComponent();
            levelEditor = editor;
            HeightBox.Enabled = false;
        }

        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            HeightBox.Text = WidthBox.Text;
        }

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
