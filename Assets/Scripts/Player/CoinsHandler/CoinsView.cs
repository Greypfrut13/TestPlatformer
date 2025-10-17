using System;
using TMPro;
using UnityEngine;

namespace Player.CoinsHandler
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private PlayerCoinsHandler _playerCoinsHandler;
        
        [SerializeField] private TextMeshProUGUI _coinsText;
        
        private void OnEnable()
        {
            _playerCoinsHandler.OnCoinsCountChanged += UpdateCoinsView;
        }

        private void OnDisable()
        {
            _playerCoinsHandler.OnCoinsCountChanged -= UpdateCoinsView;
        }

        private void UpdateCoinsView(int coinsAmount)
        {
            _coinsText.text = $"{coinsAmount}";
        }
    }
}