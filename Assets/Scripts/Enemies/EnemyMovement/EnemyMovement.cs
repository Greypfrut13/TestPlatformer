using UnityEngine;

namespace Enemies.Movement
{
    public class EnemyMovement
    {
        private float _moveSpeed;
        private LayerMask _groundLayer;
        private Transform _enemyTransform;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        
        private float _wallCheckDistance;
        private float _groundCheckDistance;
        private float _edgeCheckOffset;

        private int _moveDirection = 1;
        private Vector2 _currentVelocity;

        public EnemyMovement(float moveSpeed, LayerMask groundLayer, 
            Transform enemyTransform, float wallCheckDistance, 
            float groundCheckDistance, float edgeCheckOffset, Rigidbody2D rigidbody,
            SpriteRenderer spriteRenderer)
        {
            _moveSpeed = moveSpeed;
            _groundLayer = groundLayer;
            _enemyTransform = enemyTransform;
            _wallCheckDistance = wallCheckDistance;
            _groundCheckDistance = groundCheckDistance;
            _edgeCheckOffset = edgeCheckOffset;
            _rigidbody = rigidbody;
            _spriteRenderer = spriteRenderer;
        }

        public void HandleMovement()
        {
            if (ShouldTurnAround())
            {
                _moveDirection *= -1;
                HandleFlipBody(_moveDirection);
            }
            
            Move();
        }

        private void Move()
        {
            _currentVelocity = new Vector2(_moveDirection * _moveSpeed, _rigidbody.velocity.y);
            _rigidbody.velocity = _currentVelocity;
        }

        private bool ShouldTurnAround()
        {
            return HasWallInFront() || !HasGroundAhead();
        }

        private bool HasWallInFront()
        {
            Vector2 rayOrigin = _enemyTransform.position;
            Vector2 rayDirection = _moveDirection > 0 ? Vector2.right : Vector2.left;
            
            RaycastHit2D hit = Physics2D.Raycast(
                rayOrigin, 
                rayDirection,
                _wallCheckDistance, 
                _groundLayer);
            
            Debug.DrawRay(rayOrigin, rayDirection * _wallCheckDistance, Color.red);
            
            return hit.collider != null;
        }

        private bool HasGroundAhead()
        {
            Vector2 checkPosition = _enemyTransform.position;

            float forwardOffset = _moveDirection > 0 ? _edgeCheckOffset : -_edgeCheckOffset;
            checkPosition.x += forwardOffset;

            RaycastHit2D hit = Physics2D.Raycast(
                checkPosition,
                Vector2.down,
                _groundCheckDistance,
                _groundLayer);
            
            Debug.DrawRay(checkPosition, Vector2.down * _groundCheckDistance, Color.green);
            
            return hit.collider != null;
        }

        private void HandleFlipBody(float direction)
        {
            bool needFlip = direction < 0 ? true : false;
            _spriteRenderer.flipX = needFlip;
        }
    }
}