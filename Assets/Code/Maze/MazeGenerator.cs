using Models;
using UnityEngine;

namespace Maze
{
    public class MazeGenerator
    {
        [SerializeField] private Vector2Int size;
        private bool _visited = false;

        public MazeModel Generate()
        {
            var maze = new MazeModel(size);
            var count = maze.Cells.Length;
            var current = maze.Cells[Random.Range(0,maze.Cells.Length),Random.Range(0,maze.Cells.Length)];
            CellModel[,] unvisitedCells;
            while (count >= 0)
            {
                
                
                count -= 1;
            }
            
            return maze;
        }
    }
}