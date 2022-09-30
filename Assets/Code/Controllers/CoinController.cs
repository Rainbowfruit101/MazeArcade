using System.Collections.Generic;
using Models;
using UnityEngine;
using Utils;
using Views;

namespace Controllers
{
    public class CoinsController: MonoBehaviour
    {
        [SerializeField] private Grid grid;
        [SerializeField] private CoinView coinPrefab;

        private List<CoinView> _coinViews;
        
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
                instance.Init(coinModel, grid.WorldPositionProvider);
                instance.transform.SetParent(transform);
                
                _coinViews.Add(instance);
            }
        }
    }
}