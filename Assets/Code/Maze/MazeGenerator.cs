using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Maze
{
    public class MazeGenerator
    {
        private Vector2Int size;

        public MazeModel Generate()
        {
            var maze = new MazeModel(size);

            var current = maze.Cells[Random.Range(0, size.x), Random.Range(0, size.y)];

            var walls = new List<CellModel>();
            
            while (walls.Count!= maze.Cells.Length/2)
            {
                if (current.Position.x < size.x - 1 && current.Position.y < size.y - 1 &&
                    current.EType == CellModel.Type.Wall)
                {
                    current.EType = CellModel.Type.None;

                    var x = current.Position.x;
                    var y = current.Position.y;

                    var wallTop = maze.Cells[x, y + 1];
                    var wallBottom = maze.Cells[x, y - 1];
                    var wallLeft = maze.Cells[x - 1, y];
                    var wallRight = maze.Cells[x + 1, y];

                    walls.Add(wallTop);
                    walls.Add(wallBottom);
                    walls.Add(wallLeft);
                    walls.Add(wallRight);

                    while (walls.Count!=0)
                    {
                        var rnd = Random.Range(0, walls.Count);
                        current = walls[rnd];
                        walls.Remove(current);
                    }

                    
                }
            }
            return maze;
        }
    }
}