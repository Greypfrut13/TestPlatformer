using System;
using Player.CoinsHandler;
using UnityEngine;

namespace Coins
{
    [RequireComponent(typeof(Collider2D))]
    public class Coin : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _amount;
        
        private Collider2D _collider;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerCoinsHandler player))
            {
                player.AddCoins(_amount);
                DestroyCoin();
            }
        }

        private void DestroyCoin()
        {
            Destroy(gameObject);
        }
    }
}