using System;
using OpenTK;
using Tetriz.Game.Input;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;
using OpenTK.Input;
using Tetriz.Game.Common;

namespace Tetriz.Game.Scene.Menu
{
    public class StartButton : IGameObject
    {
        private float _width = 0.2f;
        private float _heigth = 0.1f;

        private Vector2 _startPosition;

        private string content;

        private GameWindow _game;

        public delegate void ClickHandler();

        public event ClickHandler OnClick;

        private ButtonState _lastLeftMouseButtonState = ButtonState.Released;

        private Tetriz.Game.Common.Shape.Rectangle _rectangle = new Tetriz.Game.Common.Shape.Rectangle(
            0, 0, 100, 120, Color.GreenYellow
        );

        public StartButton(GameWindow game, Vector2 startPosition)
        {
            _startPosition = startPosition;
            _game = game;
        }

        void IGameObject.OnLoad()
        {

        }

        void IGameObject.OnUpdate()
        {
            if (_lastLeftMouseButtonState != _game.Mouse.GetState().LeftButton)
            {
                if (_game.Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    if (_rectangle.IsMousePointerOverlaps(_game))
                    {
                        if(this.OnClick != null){
                            this.OnClick();
                        }
                    }
                }
            }

            _lastLeftMouseButtonState = _game.Mouse.GetState().LeftButton;
        }

        void IGameObject.OnRenderFrame()
        {
            _rectangle.OnRenderFrame();
        }
    }
}