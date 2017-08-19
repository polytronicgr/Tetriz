using Tetriz.Game.Common;
using Tetriz.Game.Common.Shape;

namespace Tetriz.Game.Scene.Board.Object.GameBlock{
    interface IGameBlock{
        void RotateLeft();

        void RotateRight();

         void SetPosition(WorldVector2d vector2D);

        Rectangle[,] GetRenderData();
    }
}