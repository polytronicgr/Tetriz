using System;
using System.Collections.Generic;
using OpenTK;
using Tetriz.Game.Input;

namespace Tetriz.Game.Scene.Menu
{

    public class MenuScene : AbstractScene
    {
        private string _sceneName = "menu";

        private List<IGameObject> _objects = new List<IGameObject>();

        public override string GetName()
        {
            return _sceneName;
        }

        public override void Load(GameWindow GameWindow)
        {
            var startButton = new StartButton(GameWindow, new Vector2(10, 10));
            startButton.OnClick += () =>
            {
                System.Diagnostics.Debug.WriteLine("Start button clicked.");
                _sceneManager.LoadScene("board");
            };

            _objects.Add(startButton);
        }

        public override void OnRenderFrame()
        {
            foreach (var o in _objects)
            {
                o.OnRenderFrame();
            }
        }

        public override void OnUpdate()
        {
            foreach (var o in _objects)
            {
                o.OnUpdate();
            }
        }
    }

}