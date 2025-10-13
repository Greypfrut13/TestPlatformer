using UnityEngine;

namespace Player.Attack
{
    public class BulletsMover
    {
        private float _speed;
        private float _direction;
        
        private Rigidbody2D _rigidbody;

        public BulletsMover(float speed, Rigidbody2D rigidbody)
        {
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public void Move()
        {
            _rigidbody.velocity = Vector2.right * (_speed * _direction);
        }

        public void SetDirection(float direction)
        {
            _direction = direction;
        }
    }
}