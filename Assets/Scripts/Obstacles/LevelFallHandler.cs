using System;
using Player.Health;
using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(Collider2D))]
    public class LevelFallHandler : UnityEngine.MonoBehaviour
    {
        private Collider2D _collider;

        private void Start()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth player))
            {
                player.Die();
            }
        }
    }
}

