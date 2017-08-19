using System;
using System.Threading;
using Tetriz.Game.Common;
using Tetriz.Game.Common.Shape;

namespace Tetriz.Game.Scene.Board.Object.GameBlock
{

    public abstract class AbstractGameBlock : IGameBlock
    {
        protected const int BLOCK_SIZE = 33;

        protected Timer _fallTimer;

        protected WorldVector2d _currentPosition = new WorldVector2d(0, 0);

        public abstract Rectangle[,] GetRenderData();

        public abstract void RotateLeft();

        public abstract void RotateRight();

        public void SetPosition(WorldVector2d vector2D)
        {
            _currentPosition = vector2D;
        }

        public AbstractGameBlock()
        {
            _fallTimer = new Timer(Fall, new AutoResetEvent(false), 1000, 1000);
        }

        protected virtual void Fall(object stateInfo)
        {
            _currentPosition.Y += BLOCK_SIZE;
        }

        protected int[,] RotateMatrix(int[,] matrix, int n)
        {
            int[,] ret = new int[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[n - j - 1, i];
                }
            }

            return ret;
        }
    }

}