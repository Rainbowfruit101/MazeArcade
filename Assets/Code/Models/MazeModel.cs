using UnityEngine;

namespace Models
{
    public class MazeModel
    {
        private readonly Vector2Int _size;
        public CellModel[,] Cells { get; }

        public CellModel this[int x, int y]
        {
            get => Cells[x, y];
            set => Cells[x, y] = value;
        }

        public CellModel this[Vector2Int pos]
        {
            get => this[pos.x, pos.y];
            set => this[pos.x, pos.y] = value;
        }
        
        public MazeModel(Vector2Int size, CellModel.Type fillType = CellModel.Type.Wall)
        {
            _size = size;
            Cells = new CellModel[_size.x, _size.y];

            for (int x = 0; x < _size.x; x++)
            {
                for (int y = 0; y < _size.y; y++)
                {
                    Cells[x, y] = new CellModel()
                    {
                        Position = new Vector2Int(x,y),
                        EType = fillType
                    };
                }
            }
        }
        
        public bool InMaze(Vector2Int position)
        {
            return position.x >= 0 && position.x < _size.x &&
                   position.y >= 0 && position.y < _size.y;
        }
    }
}