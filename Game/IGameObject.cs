namespace Tetriz.Game
{
    public interface IGameObject
    {
        void OnUpdate();

        void OnRenderFrame();

        void OnLoad();
    }
}