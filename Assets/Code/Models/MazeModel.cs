using UnityEngine;

namespace Models
{
    public class MazeModel
    {
        private readonly Vector2Int _size;
        public CellModel[,] Cells { get; }

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
    }
}