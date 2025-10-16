using System;
using Enemies.Collision;
using Enemies.Health;
using Enemies.Movement;
using Player.Health;
using UnityEngine;

namespace Enemies.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyDataSo _data;

        [Header("Components")]
        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private Rigidbody2D _bodyRigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _bodySprite;
        [SerializeField] private EnemyCollisionHandler _collisionHandler;
        
        private EnemyMovement _movement;
        private EnemyHealth _health;

        private void Awake()
        {
            _movement = new EnemyMovement(_data.MoveSpeed, _data.GroundLayer, _bodyTransform,
                _data.WallCheckDistance, _data.GroundCheckDistance, _data.EdgeCheckOffset,
                _bodyRigidbody, _bodySprite);
            _health = new EnemyHealth();
            _collisionHandler.Initialize(_health, this);
        }

        private void Update()
        {
            _movement.HandleMovement();
        }

    }
}