using ScenesLoader;
using ScenesLoader.Enums;

namespace Events
{
    public class GameEvents
    {
        private SceneLoader _sceneLoader;
        
        public GameEvents(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void OnAllCoinsCollected()
        {
            _sceneLoader.LoadScene(EGameSceneType.Menu);
        }

        public void OnTimerEnded()
        {
            _sceneLoader.LoadScene(EGameSceneType.Menu);
        }
    }
}