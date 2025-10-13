using System;
using UnityEngine;

namespace Player.Attack
{
    [Serializable]
    public class BulletsPoolData 
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _initialPoolSize;
        [SerializeField] private Transform _bulletsContainer;

        public Transform BulletsContainer => _bulletsContainer;

        public Bullet BulletPrefab => _bulletPrefab;

        public int InitialPoolSize => _initialPoolSize;
    }
}