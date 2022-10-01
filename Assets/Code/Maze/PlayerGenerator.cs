using System.Linq;
using Models;
using UnityEngine;

namespace Maze
{
    public class PlayerGenerator
    {
        private readonly MazeModel _mazeModel;
        
        public PlayerGenerator(MazeModel mazeModel)
        {
            _mazeModel = mazeModel;
        }

        public PlayerModel Generate()
        {
            var cellPosition = _mazeModel.Cells.Cast<CellModel>()
                .Where(cell => cell.EType == CellModel.Type.None)
                .OrderBy(_ => Random.Range(0, 100))
                .FirstOrDefault()!
                .Position;
            return new PlayerModel() {Position = cellPosition};
        }
    }
}