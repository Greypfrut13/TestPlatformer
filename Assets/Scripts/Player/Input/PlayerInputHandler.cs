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

            _attackActionReference.action.started += HandleAttackInput;
            _jumpActionReference.action.started += HandleJumpInput;
        }

        private void OnDisable()
        {
            _moveActionReference.action.Disable();
            _jumpActionReference.action.Disable();
            _jumpActionReference.action.Disable();
            
            _attackActionReference.action.started -= HandleAttackInput;
            _jumpActionReference.action.started -= HandleJumpInput;
        }
        
        private void Update()
        {
            HandleMovementInput();
        }
        
        private void HandleMovementInput()
        {
            float horizontalMoveInput = _moveActionReference.action.ReadValue<float>();
            float direction = horizontalMoveInput != 0 ? horizontalMoveInput : 0f;
            
            OnMoveInput?.Invoke(direction);
        }

        private void HandleJumpInput(InputAction.CallbackContext context)
        {
            if (_jumpActionReference.action.IsPressed())
            {
                OnJumpPressed?.Invoke();
            }
        }
        
        private void HandleAttackInput(InputAction.CallbackContext context)
        {
            if (_attackActionReference.action.IsPressed())
            {
                OnAttackPressed?.Invoke();
            }
        }
    }
}

