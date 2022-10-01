using System;
using Controllers;
using Models;
using UnityEngine;

namespace Views
{
    public class CoinView : MonoBehaviour
    {
        private CoinModel _model;
        private CoinsController _coinsController;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerView player))
            {
                _coinsController.OnCoinCollect(this);
            }
        }

        public void Init(CoinModel model, CoinsController coinsController, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;
            _coinsController = coinsController;
            gameObject.name = $"Coin {_model.Position}";
            transform.position = worldPositionProvider.Invoke(_model.Position);
        }
    }
}