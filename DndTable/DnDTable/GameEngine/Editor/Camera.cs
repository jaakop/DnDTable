﻿using System;
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

        /// <summary>
        /// Camera Object
        /// </summary>
        /// <param name="FovX">Field of view width</param>
        /// <param name="FovY">Field of view height</param>
        public Camera(int FovX, int FovY)
        {
            fovX = FovX;
            fovY = FovY;
            x = 0;
            y = 0;
        }
        /// <summary>
        /// Camera Object
        /// </summary>
        /// <param name="X"> The X coordinate of the camera</param>
        /// <param name="Y"> The Y coordinate of the camera</param>
        /// <param name="FovX">Field of view width</param>
        /// <param name="FovY">Field of view height</param>
        public Camera(int X, int Y, int FovX, int FovY)
        {
            x = X;
            y = Y;
            fovX = FovX;
            fovY = FovY;
        }

        /// <summary>
        /// Move the camera to a new position
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordinate</param>
        public void Move(int X, int Y)
        {
            x = X;
            y = Y;
        }
        /// <summary>
        /// Move the camera to a new position
        /// </summary>
        /// <param name="newPoint">The point to move the camera to</param>
        public void Move(Point newPoint)
        {
            x = newPoint.X;
            y = newPoint.Y;
        }
        /// <summary>
        /// Returns the location of the camera as a Point
        /// </summary>
        /// <returns></returns>
        public Point Location()
        {
            return new Point(x, y);
        }

        /// <summary>
        /// The width of the Field of view
        /// </summary>
        public int FovX { get => fovX; }
        /// <summary>
        /// The height of the Field of view
        /// </summary>
        public int FovY { get => fovY; }

    }
}