using System;
using Player.Movement;
using UnityEngine;

namespace Player.Body
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private GroundChecker _groundChecker;
        
        [Header("Animation parameters")]
        [SerializeField] private string _runParameter = "IsRunning";
        [SerializeField] private string _jumpParameter = "Jumped";
        [SerializeField] private string _groundedParameter = "IsGrounded";
        private int _runHash;
        private int _jumpHash;
        private int _groundHash;
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _runHash = Animator.StringToHash(_runParameter);
            _jumpHash = Animator.StringToHash(_jumpParameter);
            _groundHash = Animator.StringToHash(_groundedParameter);
        }

        private void OnEnable()
        {
            _playerMovement.OnMovement += HandleRunAnimation;
            _playerMovement.OnJump += HandleJumpAnimation;
            _groundChecker.OnGroundStateChanged += SetGroundedParameter;
        }

        private void OnDisable()
        {
            _playerMovement.OnMovement -= HandleRunAnimation;
            _playerMovement.OnJump -= HandleJumpAnimation;
            _groundChecker.OnGroundStateChanged -= SetGroundedParameter;
        }

        private void HandleRunAnimation(bool isRunning)
        {
            _animator.SetBool(_runHash, isRunning);
        }

        private void HandleJumpAnimation()
        {
            _animator.SetTrigger(_jumpHash);
        }

        private void SetGroundedParameter(bool isGrounded)
        {
            _animator.SetBool(_groundHash, isGrounded);
        }
    }
}