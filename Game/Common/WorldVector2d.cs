using System;
using OpenTK;

namespace Tetriz.Game.Common
{

    // Wrapper for Vector2d
    public struct WorldVector2d
    {
        private Vector2d _baseVector2d;

        public int Y
        {
            get
            {
                return (int)_baseVector2d.Y;
            }
            set
            {
                _baseVector2d.Y = value;
            }
        }

        public int X
        {
            get
            {
                return (int)_baseVector2d.X;
            }
            set
            {
                _baseVector2d.X = value;
            }
        }

        public WorldVector2d(int x, int y)
        {
            _baseVector2d = new Vector2d(x, y);
        }

        public Vector2d GetGLCoordinates()
        {
            return CoordinateConverter.ToGL(_baseVector2d);
        }

        public void AddYOffset(int y)
        {
            _baseVector2d.Y += (double)y;
        }
    }

}