using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace Tetriz.Game.Input
{
    public class MouseInput
    {
        private List<MouseButton> _buttonsDown;
        private List<MouseButton> _buttonsDownLast;

        private Vector2 _mousePosition;

        private GameWindow _game;

        public Vector2 GetPosition()
        {
            return _mousePosition;
        }

        public MouseInput(GameWindow game)
        {
            _game = game;

            _buttonsDown = new List<MouseButton>();
            _buttonsDownLast = new List<MouseButton>();

            game.MouseDown += game_MouseDown;
            game.MouseUp += game_MouseUp;
        }

        void game_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!_buttonsDown.Contains(e.Button))
                _buttonsDown.Add(e.Button);

            _mousePosition = new Vector2(e.X, e.Y);
        }
        void game_MouseUp(object sender, MouseButtonEventArgs e)
        {
            while (_buttonsDown.Contains(e.Button))
                _buttonsDown.Remove(e.Button);

            _mousePosition = new Vector2(e.X, e.Y);
        }

        public void Update()
        {
            _buttonsDownLast = new List<MouseButton>(_buttonsDown);
        }

        public bool MousePress(MouseButton button)
        {
            return (_buttonsDown.Contains(button) && !_buttonsDownLast.Contains(button));
        }
        public bool MouseRelease(MouseButton button)
        {
            return (!_buttonsDown.Contains(button) && _buttonsDownLast.Contains(button));
        }
        public bool MouseDown(MouseButton button)
        {
            return (_buttonsDown.Contains(button));
        }
    }


}