using UnityEngine;

namespace Enemies.Core
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/Enemies/EnemyData", order = 0)]
    public class EnemyDataSo : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField] [Min(0.0f)] private float _moveSpeed;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _wallCheckDistance;
        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private float _edgeCheckOffset;

        public float MoveSpeed => _moveSpeed;

        public LayerMask GroundLayer => _groundLayer;
        
        public float WallCheckDistance => _wallCheckDistance;

        public float GroundCheckDistance => _groundCheckDistance;

        public float EdgeCheckOffset => _edgeCheckOffset;

        
    }
}