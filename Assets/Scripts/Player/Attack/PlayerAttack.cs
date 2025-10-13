using Player.Input;
using Player.Movement;
using UnityEngine;

namespace Player.Attack
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private PlayerMovement _playerMovement;
        
        [SerializeField] private BulletsPoolData _poolData;
        
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
            bullet.BulletsMover.SetDirection(_playerMovement.CurrentDirection);
        }
    }
}