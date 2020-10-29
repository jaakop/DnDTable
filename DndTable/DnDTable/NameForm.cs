using System;
using System.Windows.Forms;

/// @author  Jaakko Sukuvaara
/// @version 2020
namespace DnDTable
{
    /// <summary>
    /// Name enter form
    /// </summary>
    public partial class NameForm : Form
    {
        /// <summary>
        /// New NameForm
        /// </summary>
        public NameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle OK button click
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                NewName = textBox1.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// New name
        /// </summary>
        public string NewName { get; set; }
    }
}
