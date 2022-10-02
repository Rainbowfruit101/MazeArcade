using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using Utils;
using Views;

namespace Controllers
{
    public class CoinsController : MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private CoinView coinPrefab;

        private List<CoinView> _coinViews;
        private int _collectedCoinsCount;
        
        public bool IfAllCoinsCollected { get; private set; }

        public event Action<int> OnCoinCollected;
        public event Action OnCoinsEnded;

        public void Init(CoinModel[] coins)
        {
            if (_coinViews != null)
            {
                _coinViews.ForEach(e => Destroy(e.gameObject));
                _coinViews.Clear();
            }
            else
            {
                _coinViews = new List<CoinView>();
            }

            foreach (var coinModel in coins)
            {
                var instance = Instantiate(coinPrefab.gameObject).GetComponent<CoinView>();
                instance.Init(coinModel, this, grid.WorldPositionProvider);
                instance.transform.SetParent(transform);

                _coinViews.Add(instance);
            }
        }

        public void OnCoinCollect(CoinView coinView)
        {
            _collectedCoinsCount += 1;
            OnCoinCollected?.Invoke(_collectedCoinsCount);

            _coinViews.Remove(coinView);
            Destroy(coinView.gameObject);

            IfAllCoinsCollected = _coinViews.Count == 0;
            if (IfAllCoinsCollected)
            {
                OnCoinsEnded?.Invoke();
            }
        }
    }
}