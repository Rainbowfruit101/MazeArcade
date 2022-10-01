using Models;
using UnityEngine;
using Views;
using Utils;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private PlayerView playerPrefab;

        public void Init(PlayerModel model)
        {
            var instance = Instantiate(playerPrefab.gameObject).GetComponent<PlayerView>();
            instance.Init(model, this, grid.WorldPositionProvider);
            instance.transform.SetParent(transform);
        }
        
    }
}