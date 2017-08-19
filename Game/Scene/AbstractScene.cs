namespace Tetriz.Game.Scene
{

    public abstract class AbstractScene : IScene
    {
        protected SceneManager _sceneManager;

        public abstract string GetName();
        public abstract void Load(GameWindow GameWindow);
        public abstract void OnRenderFrame();
        public abstract void OnUpdate();

        void IScene.SetSceneManager(SceneManager manager){
            _sceneManager = manager;
        }
        
    }

}