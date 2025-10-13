using System.Collections.Generic;
using UnityEngine;

namespace Player.Attack
{
    public class BulletsPool
    {
        private Bullet _bulletPrefab;
        private int _initialPoolSize;
        private Transform _bulletsContainer;
        private Transform _shootPoint;

        private Queue<Bullet> _bulletsInPool = new Queue<Bullet>();
        
        public BulletsPool(Bullet bulletPrefab, int initialPoolSize, Transform bulletsContainer, Transform shootPoint)
        {
            _bulletPrefab = bulletPrefab;
            _initialPoolSize = initialPoolSize;
            _bulletsContainer = bulletsContainer;
            _shootPoint = shootPoint;
            
            InitializePool();
        }

        public Bullet GetBullet()
        {
            Bullet bullet = _bulletsInPool.Count > 0 ? _bulletsInPool.Dequeue() : null;
            
            if (bullet != null)
            {
                bullet.gameObject.SetActive(true);
                bullet.transform.SetParent(null);
            }
            
            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _bulletsInPool.Enqueue(bullet);
            bullet.transform.SetParent(_bulletsContainer);
            bullet.transform.position = _shootPoint.position;
        }

        private void InitializePool()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                CreateBullet();
            }
        }

        private void CreateBullet()
        {
            Bullet newBullet = Object.Instantiate(_bulletPrefab, _bulletsContainer);
            newBullet.Initialize(_shootPoint, this);
            newBullet.gameObject.SetActive(false);
                
            _bulletsInPool.Enqueue(newBullet);
        }
    }
}