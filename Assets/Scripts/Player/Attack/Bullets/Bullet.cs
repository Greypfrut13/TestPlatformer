using System;
using System.Collections;
using UnityEngine;

namespace Player.Attack
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _speed;
        [SerializeField] [Min(0.0f)] private float _liveTime;

        private Rigidbody2D _rigidbody;
        
        private BulletsMover _bulletsMover;
        private BulletsPool.BulletsPool _bulletsPool;
        private BulletsCollisionHandler _bulletsCollisionHandler;
        public BulletsMover BulletsMover => _bulletsMover;
        
        public void Initialize(Transform shootPoint, BulletsPool.BulletsPool bulletsPool)
        {
            transform.position = shootPoint.position;
            _bulletsPool = bulletsPool;
            
            _rigidbody = GetComponent<Rigidbody2D>();
            _bulletsMover = new BulletsMover(_speed, _rigidbody);
            _bulletsCollisionHandler = new BulletsCollisionHandler(_bulletsPool, this);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _bulletsCollisionHandler.HandleCollision(other);
        }
        
        public void StartReturnToPool()
        {
            
        }
        
        private void FixedUpdate()
        {
            _bulletsMover.Move();
        }

        private IEnumerator ReturnToPoolAfterTime()
        {
            yield return new WaitForSeconds(_liveTime);
        }
    }
}