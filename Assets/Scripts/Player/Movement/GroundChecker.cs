using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundChecker : MonoBehaviour
    {
        public event UnityAction<bool> OnGroundStateChanged;
        
        [SerializeField] private LayerMask _groundLayer;
        
        private Collider2D _collider;
        
        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_groundLayer == (_groundLayer | (1 << other.gameObject.layer)))
            {
                IsGrounded = true;
                OnGroundStateChanged?.Invoke(IsGrounded);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_groundLayer == (_groundLayer | (1 << other.gameObject.layer)))
            {
                IsGrounded = false;
                OnGroundStateChanged?.Invoke(IsGrounded);
            }
        }
    }
}