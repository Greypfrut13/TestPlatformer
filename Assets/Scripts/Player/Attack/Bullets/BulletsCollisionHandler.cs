using UnityEngine;

namespace Player.Attack
{
    public class BulletsCollisionHandler
    {
        private BulletsPool.BulletsPool _bulletsPool;
        private Bullet _bullet;

        public BulletsCollisionHandler(BulletsPool.BulletsPool bulletsPool, Bullet bullet)
        {
            _bulletsPool = bulletsPool;
            _bullet = bullet;
        }

        public void HandleCollision(Collision2D collidedObject)
        {
            _bulletsPool.ReturnBullet(_bullet);
        }
    }
}