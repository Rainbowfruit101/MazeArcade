using Maze;
using Models;
using UnityEngine;
using UnityEngine.Serialization;
using Views;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private int amountOfCoins;
        [SerializeField] private MazeView mazeView;
        [SerializeField] private new Camera camera;
        [SerializeField] private CoinsController coinsController;
        [SerializeField] private PlayerController playerController;


        private void Awake()
        {
            var mazeGenerator = new MazeGenerator(size);
            var maze = mazeGenerator.Generate();

            var coinsGenerator = new CoinGenerator(maze, amountOfCoins);
            var coins = coinsGenerator.Generate();

            var playerGenerator = new PlayerGenerator(maze);
            var player = playerGenerator.Generate();

            mazeView.Init(maze);
            coinsController.Init(coins);
            playerController.Init(player);


            var cameraTransform = camera.transform;
            var cameraPosition = cameraTransform.position;
            cameraPosition.x = size.x / 2f;
            cameraPosition.y = size.y / 2f;

            cameraTransform.position = cameraPosition;
            camera.orthographicSize = Mathf.CeilToInt(size.y / 2f);
        }
    }
}