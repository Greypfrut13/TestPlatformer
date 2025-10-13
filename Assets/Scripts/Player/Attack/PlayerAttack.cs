using Player.Input;
using UnityEngine;

namespace Player.Attack
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private BulletsPoolData _poolData;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private Transform _shootPoint;
        
        private BulletsPool _bulletsPool;

        private void OnEnable()
        {
            _playerInputHandler.OnAttackPressed += Shoot;

            _bulletsPool = new BulletsPool(_poolData.BulletPrefab, _poolData.InitialPoolSize, _poolData.BulletsContainer, 
                _shootPoint);
        }

        private void OnDisable()
        {
            _playerInputHandler.OnAttackPressed -= Shoot;
        }

        public void Shoot()
        {
            Bullet bullet = _bulletsPool.GetBullet();
        }
    }
}