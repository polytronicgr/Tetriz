using System;
using Tetriz.Game.Common.Shape;
using Tetriz.Game.Common;

namespace Tetriz.Game.Scene.Board.Object.GameBlock
{
    public class GameBlockTest : AbstractGameBlock
    {
        private bool _currentRotation = true;

        protected int[,] _blockData1 = new int[3, 3]{
            {0,1,1},
            {1,1,0},
            {0,0,0}
        };

        protected int[,] _blockData2 = new int[3, 3]{
            {1,0,0},
            {1,1,0},
            {0,1,0}
        };

        private void swapRotation()
        {
            _currentRotation = !_currentRotation;
        }

        public override void RotateLeft()
        {
            swapRotation();
        }

        public override void RotateRight()
        {
            swapRotation();
        }

        protected override void Fall(object stateInfo){
            _blockData1 = RotateMatrix(_blockData1, 3);
            base.Fall(stateInfo);
        }

        public override Rectangle[,] GetRenderData()
        {

            Rectangle[,] result = new Rectangle[_blockData1.Rank, _blockData1.GetLength(0)];

            for (int i = 0; i < _blockData1.Rank; i++)
            {
                for (int j = 0; j < _blockData1.GetLength(0); j++)
                {
                    result[i, j] = _blockData1[i, j] == 0 ? null : new Rectangle(
                        base._currentPosition.X + i * BLOCK_SIZE,
                        base._currentPosition.Y + j * BLOCK_SIZE,
                        BLOCK_SIZE
                    );
                }
            }

            return result;
        }
    }
}