using Enemies.Core;
using UnityEngine;

namespace Enemies.Health
{
    public class EnemyHealth
    {
        public void Die(Enemy enemyObject)
        {
            GameObject.Destroy(enemyObject.gameObject);
        }
    }
}