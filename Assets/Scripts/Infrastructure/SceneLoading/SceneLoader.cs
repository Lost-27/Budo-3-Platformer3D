using Zenject;

namespace Platformer.Infrastructure.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ZenjectSceneLoader _sceneLoader;

        public SceneLoader(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void LoadScene(string sceneName) =>
            _sceneLoader.LoadScene(sceneName);
    }
}