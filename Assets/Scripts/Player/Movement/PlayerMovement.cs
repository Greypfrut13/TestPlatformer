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
        }

        private void Jump()
        { 
            if (!_groundChecker.IsGrounded) return;
                
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        }
    }
}