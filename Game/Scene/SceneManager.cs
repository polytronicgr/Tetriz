using System;
using System.Collections.Generic;
using Tetriz.Game.Exception;

namespace Tetriz.Game.Scene
{
    public class SceneManager
    {
        private List<IScene> _scenesList = new List<IScene>();

        public IScene CurrenctScene { get; private set; }

        private GameWindow _game;

        public SceneManager(GameWindow game)
        {
            _game = game;
        }

        public void LoadScene(string name)
        {
            foreach (var s in _scenesList)
            {
                if (s.GetName() == name)
                {
                    CurrenctScene = s;
                    s.Load(_game);
                    return;
                }
            }

            throw new SceneNotFoundException();
        }

        public void RegisterNewScene(IScene scene)
        {
            scene.SetSceneManager(this);
            _scenesList.Add(scene);
        }

        public void OnUpdate()
        {
            if (CurrenctScene != null)
            {
                CurrenctScene.OnUpdate();
            }
        }

        public void OnRenderFrame()
        {
            if (CurrenctScene != null)
            {
                CurrenctScene.OnRenderFrame();
            }
        }
    }
}