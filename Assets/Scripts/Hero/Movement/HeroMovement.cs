using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] [Min(0.0f)] private float _speed;
    [SerializeField] [Min(0.0f)] private float _jumpForce;

    [SerializeField] private GroundChecker _groundChecker;

    private float _direction;
    public bool _isGrounded;

    private Rigidbody2D _rigidbody;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        _isGrounded = _groundChecker.IsTouchingGround;
    }

    private void FixedUpdate() 
    {
        HorizontalMovement(_direction);
    }

    private void HorizontalMovement(float direction)
    {
        Vector3 movementDirection = new Vector3(direction * _speed, _rigidbody.velocity.y, 0);

        _rigidbody.velocity = movementDirection;
    }

    public void SetDirection(float direction)
    {
        _direction = direction;
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
