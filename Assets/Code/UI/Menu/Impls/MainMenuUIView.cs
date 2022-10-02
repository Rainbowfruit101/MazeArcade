using ObjectsStorage.Impls;
using ScenesLoader;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu.Impls
{
    public class MainMenuUIView : MenuBase
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button leaderboardButton;
        [SerializeField] private Button exitButton;

        private SceneLoader _sceneLoader;
        
        public void Init(ProgressStorageObject.Progress progress, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            
            startButton.onClick.AddListener(OnStartClicked);
            leaderboardButton.onClick.AddListener(OnLeaderboardClicked);
            exitButton.onClick.AddListener(OnExitClicked);
        }

        private void OnStartClicked()
        {
            _sceneLoader.LoadScene(GameScene.Game);
            startButton.interactable = false;
        }
        private void OnLeaderboardClicked()
        {
            MenuManager.Instance.ShowOnly<LeaderboardMenuUIView>();
        }
        private void OnExitClicked()
        {
            Application.Quit();
        }
    }
}