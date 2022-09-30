using System.Linq;
using Models;
using UnityEngine;

namespace Maze
{
    public class CoinGenerator
    {
        private readonly MazeModel _mazeModel;
        private int _amountOfCoins;

        public CoinGenerator(MazeModel mazeModel, int amountOfCoins)
        {
            _mazeModel = mazeModel;
            _amountOfCoins = amountOfCoins;
        }

        public CoinModel[] Generate()
        {
            return _mazeModel.Cells.Cast<CellModel>()
                .Where(cell => cell.EType == CellModel.Type.None)
                .OrderBy(_ => Random.Range(0, 100))
                .Take(_amountOfCoins)
                .Select(cell => new CoinModel() { Position = cell.Position })
                .ToArray();
        }
    }
}