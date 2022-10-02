using System;
using Controllers;
using Events;
using Generators;
using ObjectsStorage;
using ObjectsStorage.Impls;
using ScriptableObjects;
using UnityEngine;
using Views;

namespace ScenesLoader.SceneLaunchers.Impls
{
    public class GameSceneLauncher : SceneLauncherBase
    {
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private CoinsController coinsController;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private TimerController timerController;

        [SerializeField] private MazeView mazeView;

        public event Action OnGameStarted;

        private ProgressStorageObject _progressStorageObject;
        private GameStateStorageObject _gameStateStorageObject;
        private GameEvents _sceneEvents;

        public override void Load(SceneLoader sceneLoader)
        {
            _sceneEvents = new GameEvents(sceneLoader);
            coinsController.OnCoinsEnded += _sceneEvents.OnAllCoinsCollected;
            timerController.OnTimerEnded += _sceneEvents.OnTimerEnded;
            
            _progressStorageObject = Storage
                .Load<ProgressStorageObject, ProgressStorageObject.Progress>(new ProgressStorageObject());

            _gameStateStorageObject = Storage
                .Load<GameStateStorageObject, GameStateStorageObject.GameState>(new GameStateStorageObject());

            /*var maze = _gameStateStorageObject.Data.MazeModel;
            var coins = _gameStateStorageObject.Data.CoinModels;
            var player = _gameStateStorageObject.Data.PlayerModel;
            var isLevelStarted = _gameStateStorageObject.Data.IsCurrentLevelStarted;

            if (!isLevelStarted)
            {
                
            }*/

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
            
            OnGameStarted?.Invoke();
            _gameStateStorageObject.Data.IsCurrentLevelStarted = true;
        }

        public override void Unload(SceneLoader sceneLoader)
        {
            coinsController.OnCoinsEnded -= _sceneEvents.OnAllCoinsCollected;
            timerController.OnTimerEnded -= _sceneEvents.OnTimerEnded;
            
            Storage.Save<ProgressStorageObject, ProgressStorageObject.Progress>(_progressStorageObject);

            _gameStateStorageObject.Data.IsCurrentLevelStarted = !coinsController.IfAllCoinsCollected;
            Storage.Save<GameStateStorageObject, GameStateStorageObject.GameState>(_gameStateStorageObject);
        }
    }
}