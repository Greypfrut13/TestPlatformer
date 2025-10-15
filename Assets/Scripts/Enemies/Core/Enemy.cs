using System;
using UnityEngine;

namespace Enemies.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyDataSo _data;

        [SerializeField] private Transform _bodyTransform;
        [SerializeField] private Rigidbody2D _bodyRigidbody;
        
        private EnemyMovement.EnemyMovement _movement;

        private void Awake()
        {
            _movement = new EnemyMovement.EnemyMovement(_data.MoveSpeed, _data.GroundLayer, _bodyTransform,
                _data.WallCheckDistance, _data.GroundCheckDistance, _data.EdgeCheckOffset,
                _bodyRigidbody);
        }

        private void Update()
        {
            _movement.HandleMovement();
        }
    }
}