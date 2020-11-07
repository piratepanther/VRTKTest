using UnityEngine;
using System.Collections;
using Common;

namespace Assets.Script.Weapon
{
    public class EnemyBullet : Bullet
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = other.GetComponent<PlayerStatus>();
            if (player != null)
            {
                player.Damage(atk);
                GameObjectPool.instance.CollectObject(gameObject);
            }

        }

    }
}