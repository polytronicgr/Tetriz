using OpenTK;

namespace Tetriz.Game.Common
{
    public abstract class CoordinateConverter
    {
        private const int WORLD_GRID_WIDTH = 1280;
        private const int WORLD_GRID_HEIGTH = 720;

        public static Vector2d ToWorld(float x, float y)
        {

            Vector2d result = new Vector2d(
                WORLD_GRID_WIDTH / ((x + 1) / 2),
                WORLD_GRID_HEIGTH / ((y + 1) / 2)
            );

            return result;
        }

        public static Vector2d ToWorld(Vector2d input)
        {

            Vector2d result = new Vector2d(
                WORLD_GRID_WIDTH / ((input.X + 1) / 2),
                WORLD_GRID_HEIGTH / ((input.Y + 1) / 2)
            );

            return result;
        }

        public static Vector2d ToGL(Vector2d input)
        {
            float x = (((float)input.X) / (float)WORLD_GRID_WIDTH * 2) - 1;
            float y = ((((float)input.Y) / (float)WORLD_GRID_HEIGTH * 2) - 1) * -1;

            return new Vector2d(x, y);
        }

    }
}