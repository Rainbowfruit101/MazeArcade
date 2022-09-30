using UnityEngine;

namespace Utils
{
    public static class GridExt
    {
        public static Vector3 WorldPositionProvider(this Grid grid, Vector2Int gridPosition)
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