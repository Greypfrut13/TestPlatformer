using Enemies.Core;
using Enemies.Health;
using Player.Health;
using UnityEngine;

namespace Enemies.Collision
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyCollisionHandler : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;
        private Enemy _enemyObject;
        private Collider2D _collider;
        
       [SerializeField] private float _playerAboveThreshold;
        
        public void Initialize(EnemyHealth enemyHealth, Enemy enemyObject)
        {
            _enemyHealth = enemyHealth;
            _enemyObject = enemyObject;
            
            _collider = GetComponent<Collider2D>();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerHealth player))
            {
                Vector2 contactPoint = CalculateContactPoint(other);
                HandleCollisionWithPlayer(player, contactPoint);
            }
        }
        
        private void HandleCollisionWithPlayer(PlayerHealth player, Vector2 contactPoint)
        {
            if (IsPlayerAbove(contactPoint))
            {
                _enemyHealth.Die(_enemyObject);
            }
            else
            {
                player.TakeDamage();
            }
        }

        private bool IsPlayerAbove(Vector2 contactPoint)
        {
            float enemyTop = _collider.bounds.max.y;
            float contactHeight = contactPoint.y;

            return Mathf.Abs(contactHeight - enemyTop) < _playerAboveThreshold;
        }
        
        private Vector2 CalculateContactPoint(Collider2D playerCollider)
        {
            Vector2 playerBottom = new Vector2(
                playerCollider.bounds.center.x,
                playerCollider.bounds.min.y
            );
            
            return playerBottom;
        }
    }
}