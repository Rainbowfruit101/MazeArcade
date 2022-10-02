using ScenesLoader.Enums;
using ScenesLoader.SceneLaunchers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenesLoader
{
    public class SceneLoader: MonoBehaviour
    {
        [SerializeField] private EGameSceneType firstScene;

        private EGameSceneType _currentScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            LoadScene(firstScene);
        }

        public void LoadScene(EGameSceneType sceneToLoad)
        {
            if(sceneToLoad == EGameSceneType.None)
                return;
            
            var currentSceneLauncher = FindObjectOfType<SceneLauncherBase>();
            if (currentSceneLauncher != null)
            {
                currentSceneLauncher.Unload(this);
            }
            
            var loadOperation = SceneManager.LoadSceneAsync((int) sceneToLoad);
            loadOperation.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            var currentSceneLauncher = FindObjectOfType<SceneLauncherBase>();
            if (currentSceneLauncher != null)
            {
                currentSceneLauncher.Load(this);
            }
        }
    }
}