namespace Tetriz.Game.Scene
{
    public interface IScene
    {
        string GetName();

        void Load(GameWindow GameWindow);

        void OnUpdate();

        void OnRenderFrame();

        void SetSceneManager(SceneManager manager);
    }
}