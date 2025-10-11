using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public event UnityAction<float> OnMoveInput;
        public event UnityAction OnJumpPressed;
        public event UnityAction OnAttackPressed;
        
        [SerializeField] private InputActionReference _moveActionReference;
        [SerializeField] private InputActionReference _jumpActionReference;
        [SerializeField] private InputActionReference _attackActionReference;
        
        private void OnEnable()
        {
            _moveActionReference.action.Enable();
            _jumpActionReference.action.Enable();
            _attackActionReference.action.Enable();
        }

        private void OnDisable()
        {
            _moveActionReference.action.Disable();
            _jumpActionReference.action.Disable();
            _jumpActionReference.action.Disable();
        }
        
        private void Update()
        {
            HandleMovementInput();
            HandleJumpInput();
            HandleAttackInput();
        }
        
        private void HandleMovementInput()
        {
            float horizontalMoveInput = _moveActionReference.action.ReadValue<float>();

            if (horizontalMoveInput != 0)
            {
                OnMoveInput?.Invoke(horizontalMoveInput);
            }
        }

        private void HandleJumpInput()
        {
            if (_jumpActionReference.action.IsPressed())
            {
                OnJumpPressed?.Invoke();
            }
        }
        
        private void HandleAttackInput()
        {
            if (_attackActionReference.action.IsPressed())
            {
                OnAttackPressed?.Invoke();
            }
        }
    }
}

