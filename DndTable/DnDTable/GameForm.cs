using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using GameEngine;
using GameEngine.Level;

namespace DnDTable
{
    public partial class GameForm : Form
    {
        Graphics graphics;
        Level level;
        public GameForm(Screen screen)
        {
            InitializeComponent();
            //Application.Idle += Application_Idle;
            DoubleBuffered = true;
            
            Rectangle bounds = screen.Bounds;
            Bounds = bounds;
            
            graphics = CreateGraphics();

            Layer layer = new Layer();
            for(int i = 0; i < 32; i++)
            {
                for(int j = 0; j < 18; j++)
                {
                    Tile tile = new Tile(i, j, Properties.Resources.download);
                    layer.AddTile(tile);
                }
            }
            layer.AddTile(new Tile(1, 1));
            level = new Level();
            level.AddALayer(layer);
        }



        #region
        /*
        void GameUpdate()
        {
            Invalidate();
        }
        //GameLoop DO NOT TOUCH
        //NO EVEN TOUCHY TOUCHY
        //*not sure why it works*
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        private void Application_Idle(object sender, EventArgs e)
        {
            while (IsApplicationIdle())
            {
                GameUpdate();
                //Invalidate();
            }
        }
        private bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        }*/
        #endregion

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            level.DrawLevel(e.Graphics, 60);
        }
    }
}
