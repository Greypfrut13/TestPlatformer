using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Health
{
    public class PlayerHealth : MonoBehaviour
    {
        public event UnityAction<int> OnHealthChanged;
        public event UnityAction OnDeath;
        
        [SerializeField] [Min(0)] private int _maxHealth = 3;
        
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }
        
        public void TakeDamage()
        {
            _currentHealth--;
            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                Debug.Log("Death");
            }
        }
    }
}