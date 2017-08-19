using System;
using System.Collections.Generic;
using OpenTK;
using Tetriz.Game.Common.Shape;
using Tetriz.Game.Scene.Board.Object;

namespace Tetriz.Game.Scene.Board
{

    public class BoardScene : AbstractScene
    {
        private List<IGameObject> _objects = new List<IGameObject>();

        public override string GetName()
        {
            return "board";
        }

        public override void Load(GameWindow GameWindow)
        {
            var gameBoard = new GameBoard();
            gameBoard.OnLoad();
            _objects.Add(gameBoard);
        }

        public override void OnRenderFrame()
        {
            foreach(var o in _objects){
                o.OnRenderFrame();
            }
        }

        public override void OnUpdate()
        {
            
        }
    }

}