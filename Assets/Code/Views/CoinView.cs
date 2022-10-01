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

        public void Init(CoinModel model, CoinsController coinsController, Func<Vector2Int, Vector3> worldPositionProvider)
        {
            _model = model;
            _coinsController = coinsController;
            gameObject.name = $"Coin {_model.Position}";
            transform.position = worldPositionProvider.Invoke(_model.Position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player))
            {
                _coinsController.OnCoinCollect(_model,this); 
            }
        }
    }
}