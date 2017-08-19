using System;
using System.Collections.Generic;
using OpenTK;
using Tetriz.Game;
using Tetriz.Game.Common;
using Tetriz.Game.Scene.Board.Object.GameBlock;

namespace Tetriz.Game.Scene.Board.Object
{

    public class GameBoard : IGameObject
    {
        private const int GRID_SIZE_COLS = 10;
        private const int GRID_SIZE_ROWS = 20;
        private const int GRID_START_LEFT = 475;
        private const int GRID_START_TOP = 30;
        private const int BLOCK_SIZE = 33;
        private object[,] _blocks = new object[GRID_SIZE_COLS, GRID_SIZE_ROWS];
        private IGameBlock[,] _gameBlocks = new IGameBlock[GRID_SIZE_COLS, GRID_SIZE_ROWS];

        private Common.Shape.Rectangle _mainGameBoardShape = new Common.Shape.Rectangle(
            GRID_START_LEFT,
            GRID_START_TOP,
            BLOCK_SIZE * GRID_SIZE_COLS,
            BLOCK_SIZE * GRID_SIZE_ROWS,
            Color.White
        );

        private void CreateBlock(int row, int col)
        {
            _blocks[col, row] =
            new Common.Shape.Rectangle(
                GRID_START_LEFT + col * BLOCK_SIZE,
                GRID_START_TOP + row * BLOCK_SIZE,
                BLOCK_SIZE,
                BLOCK_SIZE,
                Color.Red
            );
        }

        public void DestroyRowAndMoveRemainingDown(int destroyedRow)
        {
            for (int row = destroyedRow; row >= 0; row--)
            {
                for (int col = 0; col < GRID_SIZE_COLS; col++)
                {
                    if (row == 0)
                    { // if first row on top
                        _blocks[col, row] = null;
                    }
                    else
                    {
                        if (_blocks[col, row - 1] != null)
                        {
                            CreateBlock(row, col);
                        }
                        else
                        {
                            DestroyBlock(row, col);
                        }
                    }


                }
            }
        }

        public void DestroyBlock(int row, int col)
        {
            _blocks[col, row] = null;
        }

        public void OnLoad()
        {
            CreateBlock(0, 0);
            CreateBlock(1, 0);
            CreateBlock(2, 0);
            CreateBlock(19, 9);
            CreateBlock(19, 8);
            CreateBlock(19, 7);
            CreateBlock(19, 6);
            CreateBlock(19, 5);
            CreateBlock(19, 4);
            CreateBlock(19, 3);
            CreateBlock(19, 2);
            CreateBlock(19, 1);
            CreateBlock(19, 0);
            CreateBlock(18, 0);
            _gameBlocks[0, 0] = new GameBlockTest();
            _gameBlocks[0, 0].SetPosition(new WorldVector2d(
                GRID_START_LEFT + BLOCK_SIZE,
                GRID_START_TOP + BLOCK_SIZE
            ));
            //DestroyRowAndMoveRemainingDown(19);
        }

        public void OnRenderFrame()
        {
            _mainGameBoardShape.OnRenderFrame();
            foreach (var b in _gameBlocks[0, 0].GetRenderData())
            {
                if (null != b)
                    b.OnRenderFrame();
            }

            for (int row = 0; row < GRID_SIZE_ROWS; row++)
            {
                for (int col = 0; col < GRID_SIZE_COLS; col++)
                {

                    if (_blocks[col, row] != null)
                    {
                        ((Common.Shape.Rectangle)_blocks[col, row]).OnRenderFrame();
                    }
                }
            }
        }

        public void OnUpdate()
        {

        }
    }

}