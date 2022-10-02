using Controllers;
using ScenesLoader;
using ScenesLoader.Enums;

namespace Listeners
{
    public class GameEvents
    {
        private SceneLoader _sceneLoader;
        
        public GameEvents(SceneLoader sceneLoader, CoinsController coinsController, TimerController timerController)
        {
            _sceneLoader = sceneLoader;
            coinsController.OnCoinsEnded += OnAllCoinsCollected;
            timerController.OnTimerEnded += OnTimerEnded;
        }

        private void OnAllCoinsCollected()
        {
            _sceneLoader.LoadScene(EGameSceneType.Menu);
        }

        private void OnTimerEnded()
        {
            _sceneLoader.LoadScene(EGameSceneType.Menu);
        }
    }
}