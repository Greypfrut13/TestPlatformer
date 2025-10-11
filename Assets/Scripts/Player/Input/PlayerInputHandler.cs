using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private InputActionReference _moveActionReference;
        [SerializeField] private InputActionReference _jumpActionReference;
        [SerializeField] private InputActionReference _attackActionReference;

        public float HorizontalMoveInput { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool AttackPressed { get; private set; }
        
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
            HorizontalMoveInput = _moveActionReference.action.ReadValue<float>();
            JumpPressed = _jumpActionReference.action.IsPressed();
            AttackPressed = _attackActionReference.action.IsPressed();
        }
    }
}

