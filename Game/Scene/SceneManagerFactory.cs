using Tetriz.Game.Scene.Board;
using Tetriz.Game.Scene.Menu;

namespace Tetriz.Game.Scene
{
    public abstract class SceneManagerFactory
    {
        public static SceneManager Produce(GameWindow window)
        {
            var manager = new SceneManager(window);

            manager.RegisterNewScene(new MenuScene());
            manager.RegisterNewScene(new BoardScene());

            return manager;
        }
    }
}