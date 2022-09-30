using System;
using Models;
using UnityEngine;

namespace Views
{
    public class CoinView : MonoBehaviour
    {
        private CoinModel _model;
        
        public void Init(CoinModel model, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;
            
            gameObject.name = $"Coin {_model.Position}";
            transform.position = worldPositionProvider.Invoke(_model.Position);

        }
    }
}