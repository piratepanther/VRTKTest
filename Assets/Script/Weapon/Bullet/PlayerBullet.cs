using UnityEngine;
using System.Collections;

namespace Assets.Script.Weapon
{
    [RequireComponent(typeof(GenerateEffect))]
    public class PlayerBullet : Bullet
	{
        //根据部位改变攻击力

        private void ChangeAttackForce()
        {
            //base.atk*=0.5f
            //switch (base.hit.collider.name) { }
            //或者写配置文件
            switch (base.hit.collider.name)
            {
                case "Coll_Head":
                    base.atk *= 2f;
                    break;
                case "Coll_Body":
                    base.atk *= 1.5f;
                    break;
                default:
                    base.atk *= 0.5f;
                    break;

            }



        }

        protected override void ArriveTargetPoint()
        {
            base.ArriveTargetPoint();//回收


            ChangeAttackForce();
            if (hit.collider == null) return;
            //伤害敌人
            var state = hit.collider.GetComponentInParent<EnemyStatus>();
            if (state!=null)state.Damage(atk);
                       

        }


	}
}
