using Controllers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsUIView: MonoBehaviour
    {
        [SerializeField] private CoinsController controller;
        [SerializeField] private TMP_Text valuePlace;

        private void Awake()
        {
            controller.OnCoinCollected += OnCoinCollected;
        }

        private void OnDestroy()
        {
            controller.OnCoinCollected -= OnCoinCollected;
        }

        private void OnCoinCollected(int collectedCoinsCount)
        {
            valuePlace.text = collectedCoinsCount.ToString("000");
        }
    }
}