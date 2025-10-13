using System;
using Player.Input;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _moveSpeed;
        [SerializeField] [Min(0.0f)] private float _jumpForce;
        
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private GroundChecker _groundChecker;
        
        private Rigidbody2D _rigidbody;
        private float _currentDirection = 1f;
        
        public float CurrentDirection => _currentDirection;
        
        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _playerInputHandler.OnJumpPressed += Jump;
            _playerInputHandler.OnMoveInput += HandleMovement;
        }

        private void OnDisable()
        {
            _playerInputHandler.OnJumpPressed -= Jump;
            _playerInputHandler.OnMoveInput -= HandleMovement;
        }
        
        
        private void HandleMovement(float direction)
        {
            float targetVelocityX = direction * _moveSpeed;
            
            _rigidbody.velocity = new Vector2(targetVelocityX, _rigidbody.velocity.y);

            if (direction != 0)
            {
                UpdatePlayerDirection(direction);
            }
        }

        private void Jump()
        { 
            if (!_groundChecker.IsGrounded) return;
                
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        }

        private void UpdatePlayerDirection(float direction)
        {
            if (direction != _currentDirection)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                    transform.localScale.y, transform.localScale.z);
                
                _currentDirection = direction;
            }
        }
    }
}