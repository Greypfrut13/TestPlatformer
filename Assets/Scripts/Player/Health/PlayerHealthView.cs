using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Health
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;

        [SerializeField] private Image _heartPrefab;
        [SerializeField] private RectTransform _heartsContainer;

        private List<Image> _hearts = new List<Image>();
        
        private void OnEnable()
        {
            _playerHealth.OnHealthChanged += HealthChangedHandle;
        }

        private void OnDisable()
        {
            _playerHealth.OnHealthChanged -= HealthChangedHandle;
        }

        private void HealthChangedHandle(int health)
        {
            if (health > _hearts.Count)
            {
                for (int i = 0; i < health; i++)
                {
                    CreateHeartIcon();
                }
            }
            else
            {
                RemoveHeartIcon();
            }
        }

        private void CreateHeartIcon()
        { 
            var heart =Instantiate(_heartPrefab, _heartsContainer);
            _hearts.Add(heart);
        }

        private void RemoveHeartIcon()
        {
            var heartToRemove = _hearts.Count - 1;

            Destroy(_hearts[heartToRemove].gameObject);
            _hearts.RemoveAt(heartToRemove);
        }
    }
}