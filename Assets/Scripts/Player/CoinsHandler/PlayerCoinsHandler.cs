using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.CoinsHandler
{
    public class PlayerCoinsHandler : MonoBehaviour
    {
        public event UnityAction<int> OnCoinsCountChanged;
        
        private int _currentCoins;

        private void Start()
        {
            OnCoinsCountChanged?.Invoke(_currentCoins);
        }

        public void AddCoins(int amount)
        {
            _currentCoins += amount;
            
            OnCoinsCountChanged?.Invoke(_currentCoins);
        }
    }
}