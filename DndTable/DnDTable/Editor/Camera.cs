using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace DnDTable.Editor
{
    public class Camera
    {
        int x;
        int y;
        int fovX;
        int fovY;

        public Camera(int FovX, int FovY)
        {
            fovX = FovX;
            fovY = FovY;
            x = 0;
            y = 0;
        }
        public Camera(int X, int Y, int FovX, int FovY)
        {
            x = X;
            y = Y;
            fovX = FovX;
            fovY = FovY;
        }
        public void Move(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void Move(Point newPoint)
        {
            x = newPoint.X;
            y = newPoint.Y;
        }

        public Point Location()
        {
            return new Point(x, y);
        }

        public int FovX { get => fovX; }
        public int FovY { get => fovY; }

    }
}
