using System.Collections.Generic;
using Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Maze
{
    public class MazeGenerator
    {
        private readonly Vector2Int _size;

        public MazeGenerator(Vector2Int size)
        {
            _size = size;
        }

        public MazeModel Generate()
        {
            var maze = new MazeModel(_size);

            var current = maze.Cells[Random.Range(0, _size.x / 2) * 2 + 1, Random.Range(0, _size.y / 2) * 2 + 1];
            current.EType = CellModel.Type.None;
            
            var walls = new List<CellModel>();

            if (current.Position.y - 2 >= 0)
            {
                walls.Add(maze.Cells[current.Position.x, current.Position.y - 2]);
            }

            if (current.Position.y + 2 < _size.y)
            {
                walls.Add(maze.Cells[current.Position.x, current.Position.y + 2]);
            }

            if (current.Position.x - 2 >= 0)
            {
                walls.Add(maze.Cells[current.Position.x - 2, current.Position.y]);
            }

            if (current.Position.x + 2 < _size.x)
            {
                walls.Add(maze.Cells[current.Position.x + 2, current.Position.y]);
            }

            while (walls.Count > 0)
            {
                var rndIndex = Random.Range(0, walls.Count);
                current = walls[rndIndex];
                walls.RemoveAt(rndIndex);
                current.EType = CellModel.Type.None;

                var directions = new List<Vector2Int>
                {
                    Vector2Int.up,
                    Vector2Int.down,
                    Vector2Int.left,
                    Vector2Int.right
                };

                while (directions.Count > 0)
                {
                    rndIndex = Random.Range(0, directions.Count);
                    var dir = directions[rndIndex];
                    directions.RemoveAt(rndIndex);

                    var nearestPosition = current.Position + dir;
                    var nextPosition = current.Position + (dir * 2);
                    
                    if (maze.InMaze(nextPosition) && maze[nextPosition].EType == CellModel.Type.None)
                    {
                        maze[nearestPosition].EType = CellModel.Type.None;
                        directions.Clear();
                    }
                }

                if (current.Position.y - 2 >= 0 && maze.Cells[current.Position.x, current.Position.y - 2].EType == CellModel.Type.Wall)
                {
                    walls.Add(maze.Cells[current.Position.x, current.Position.y - 2]);
                }

                if (current.Position.y + 2 < _size.y && maze.Cells[current.Position.x, current.Position.y + 2].EType == CellModel.Type.Wall)
                {
                    walls.Add(maze.Cells[current.Position.x, current.Position.y + 2]);
                }

                if (current.Position.x - 2 >= 0 && maze.Cells[current.Position.x - 2, current.Position.y].EType == CellModel.Type.Wall)
                {
                    walls.Add(maze.Cells[current.Position.x - 2, current.Position.y]);
                }

                if (current.Position.x + 2 < _size.x && maze.Cells[current.Position.x + 2, current.Position.y].EType == CellModel.Type.Wall)
                {
                    walls.Add(maze.Cells[current.Position.x + 2, current.Position.y]);
                }
            }

            return maze;
        }
    }
}