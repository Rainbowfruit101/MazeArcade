using System.Linq;
using Models;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace Views
{
    public class MazeView: MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private CellView cellViewPrefab;
        
        public void Init(MazeModel model)
        {
            var cells = model.Cells.Cast<CellModel>();

            foreach (var cellModel in cells)
            {
                var instance = Instantiate(cellViewPrefab.gameObject).GetComponent<CellView>();
                instance.Init(cellModel, WorldPositionProvider);
            }
        }

        private Vector3 WorldPositionProvider(Vector2Int gridPosition)
        {
            var gridPositionV3 = new Vector3Int()
            {
                x = gridPosition.x,
                y = gridPosition.y,
                z = 0
            };
            return grid.GetCellCenterWorld(gridPositionV3);
        }
    }
}