using Controllers;
using Generators;
using ObjectsStorage;
using ObjectsStorage.Impls;
using ScriptableObjects;
using UnityEngine;
using Views;

namespace ScenesLoader.Impls
{
    public class OnGameSceneLoaded: OnSceneLoaded
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private CoinsController coinsController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private CameraController cameraController;
        
        [SerializeField] private MazeView mazeView;

        private ProgressStorageObject _progressStorageObject;
        
        public override void Load(SceneLoader sceneLoader)
        {
            _progressStorageObject = Storage
                .Load<ProgressStorageObject, ProgressStorageObject.Progress>(new ProgressStorageObject());

            var mazeGenerator = new MazeGenerator(gameSettings.Size);
            var maze = mazeGenerator.Generate();

            var coinsGenerator = new CoinGenerator(maze, gameSettings.AmountOfCoins);
            var coins = coinsGenerator.Generate();

            var playerGenerator = new PlayerGenerator(maze);
            var player = playerGenerator.Generate();

            mazeView.Init(maze);
            coinsController.Init(coins);
            playerController.Init(player);
            
            cameraController.Init(gameSettings.Size);
        }

        public override void Unload(SceneLoader sceneLoader)
        {
            Storage.Save<ProgressStorageObject, ProgressStorageObject.Progress>(_progressStorageObject);
        }
    }
}