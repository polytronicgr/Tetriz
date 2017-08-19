using System;
using Tetriz;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace Tetriz.Game.Common.Shape
{

    public class Rectangle
    {
        private Vector2d _leftTopPosition;
        private Vector2d _rightBottomPosition;
        private Vector2d _leftBottomPosition;
        private Vector2d _rightTopPosition;

        private Color _color;

        public void MoveTo(){

        }

        public void MoveBy(){
            
        }

        public Rectangle(
            int left, int top,
            int size
        )
        {
            _color = Color.GreenYellow;

            System.Diagnostics.Debug.WriteLine(
                "Creating Rectangle at: {0}, {1}, with size of: {2}, {3}", left, top, size, size
            );

            _leftTopPosition = new Vector2d(left, top);
            _leftBottomPosition = new Vector2d(left, top + size);
            _rightBottomPosition = new Vector2d(left + size, top + size);
            _rightTopPosition = new Vector2d(left + size, top);
        }

        public Rectangle(
            int left, int top,
            int width, int height
        )
        {
            _color = Color.GreenYellow;

            System.Diagnostics.Debug.WriteLine(
                "Creating Rectangle at: {0}, {1}, with size of: {2}, {3}", left, top, width, height
            );

            _leftTopPosition = new Vector2d(left, top);
            _leftBottomPosition = new Vector2d(left, top + height);
            _rightBottomPosition = new Vector2d(left + width, top + height);
            _rightTopPosition = new Vector2d(left + width, top);
        }

        public Rectangle(
            int left, int top,
            int width, int height,
            Color color
        )
        {
            _color = color;

            System.Diagnostics.Debug.WriteLine(
                "Creating Rectangle at: {0}, {1}, with size of: {2}, {3}", left, top, width, height
            );

            _leftTopPosition = new Vector2d(left, top);
            _leftBottomPosition = new Vector2d(left, top + height);
            _rightBottomPosition = new Vector2d(left + width, top + height);
            _rightTopPosition = new Vector2d(left + width, top);
        }

        public bool IsMousePointerOverlaps(GameWindow game)
        {
            if (game.Mouse.X >= _leftTopPosition.X && game.Mouse.X <= _rightTopPosition.X)
            {
                System.Diagnostics.Debug.WriteLine("X => true");

                if (game.Mouse.Y >= _leftTopPosition.Y && game.Mouse.Y <= _leftBottomPosition.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public void OnRenderFrame()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(_color);

            GL.Vertex2(CoordinateConverter.ToGL(_leftTopPosition)); // left top
            GL.Vertex2(CoordinateConverter.ToGL(_leftBottomPosition)); // left bottom
            GL.Vertex2(CoordinateConverter.ToGL(_rightBottomPosition)); // right bottom
            GL.Vertex2(CoordinateConverter.ToGL(_rightTopPosition)); // right top

            GL.End();
        }
    }

}