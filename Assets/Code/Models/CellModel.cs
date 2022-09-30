using UnityEngine;

namespace Models
{
    public class CellModel
    {
        public enum Type
        {
            None,
            Wall
        }
    
        public Vector2Int Position { get; set; }
        public Type EType { get; set; }
    }
}