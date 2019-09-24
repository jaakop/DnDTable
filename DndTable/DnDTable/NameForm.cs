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
    public partial class NameForm : Form
    {
        public NameForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                this.NewName = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public string NewName { get; set; }
    }
}
