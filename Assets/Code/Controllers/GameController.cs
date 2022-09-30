using Maze;
using Models;
using UnityEngine;
using Views;

namespace Controllers
{
    public class GameController: MonoBehaviour
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private int amountOfCoins;
        [SerializeField] private MazeView mazeView;
        [SerializeField] private new Camera camera;
        

        private void Awake()
        {
            var mazeGenerator = new MazeGenerator(size);
            var maze = mazeGenerator.Generate();

            var coinsGenerator = new CoinGenerator(maze, amountOfCoins);
            var coins = coinsGenerator.Generate();
            
            mazeView.Init(maze);
            
            var cameraTransform = camera.transform;
            var cameraPosition = cameraTransform.position;
            cameraPosition.x = size.x / 2f;
            cameraPosition.y = size.y / 2f;

            cameraTransform.position = cameraPosition;
            camera.orthographicSize = Mathf.CeilToInt(size.y / 2f);
        }
    }
}