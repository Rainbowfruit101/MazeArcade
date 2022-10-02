using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenesLoader
{
    public class SceneLoader: MonoBehaviour
    {
        [SerializeField] private GameScene firstScene;

        private GameScene _currentScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            LoadScene(firstScene);
        }

        public void LoadScene(GameScene sceneToLoad)
        {
            if(sceneToLoad == GameScene.None)
                return;
            
            var loader = FindObjectOfType<OnSceneLoaded>();
            if (loader != null)
            {
                loader.Unload(this);
            }
            
            var loadOperation = SceneManager.LoadSceneAsync((int) sceneToLoad);
            loadOperation.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation operation)
        {
            var loader = FindObjectOfType<OnSceneLoaded>();
            if (loader != null)
            {
                loader.Load(this);
            }
        }
    }
}