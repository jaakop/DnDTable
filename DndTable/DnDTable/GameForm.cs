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
    public partial class GameForm : Form
    {
        public GameForm(Screen screen)
        {
            InitializeComponent();
            Rectangle bounds = screen.Bounds;
            Bounds = bounds;
        }
    }
}
