using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Maze/GameSettings")]
    public class GameSettings: ScriptableObject
    {
        [SerializeField] private Vector2Int size;
        [SerializeField] private int amountOfCoins;

        public Vector2Int Size => size;

        public int AmountOfCoins => amountOfCoins;
    }
}