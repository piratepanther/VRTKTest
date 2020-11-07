using UnityEngine;
using System.Collections;
using Common;
using System;

namespace Assets.Script.Weapon
{
	public class Bullet : MonoBehaviour,IResetable
	{
        private Vector3 targetPoint;
        [Tooltip("移动速度")]
        public float moveSpeed = 100;
        [Tooltip("攻击距离")]
        public float attackDistance = 100;
        [Tooltip("射线检测层")]
        public LayerMask layer;
        [Tooltip("子弹攻击力")]
        public float atk;
        protected RaycastHit hit;
        public event EventHandler<BulletArrivedEventArgs> ArrivedTargetPoint;

        //消息到达（事件源）
        //1.定义事件参数类
        //2.定义委托数据类型（也可以使用泛型委托）
//         EventHandler(object sender,TEventArgs e)
//             Action<BulletArrivedEventArgs>
        //3.声明事件
        //4.引发事件
        //----------------------
        //5.注册事件



        public void OnReset()
        {
            CalculateTargetPoint(); 
        }
        
        private void Update()
        {
            MoveToTarget();
            if (Vector3.Distance(transform.position, targetPoint) <= 0.1)
            {
                ArriveTargetPoint();


            }


        }
        //到达目标点：
        //1.对象池回收

        protected virtual void ArriveTargetPoint()
        {

            if (ArrivedTargetPoint != null)
            {
                BulletArrivedEventArgs args = new BulletArrivedEventArgs() 
                {
                    Hit=hit
                };
                ArrivedTargetPoint(this, args);

            }


            GameObjectPool.instance.CollectObject(gameObject);
        }         
        
        
        //1.计算目标点
        private void CalculateTargetPoint()
        {
            //targetPoint = transform.TransformPoint(0, 0, 100);
            if (Physics.Raycast(transform.position, transform.forward, out hit, attackDistance, layer))
            {
                //击中目标
                targetPoint = hit.point;

            }
            else
            {
                //目标点为正前方100m
                targetPoint = transform.TransformPoint(0, 0, 100);

            }

        }

        //2.朝向目标点移动
        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, Time.deltaTime*moveSpeed);
        }

        //问题：
        //1.实现玩家攻击敌人（角色系统）
        //--枪将攻击力传递给子弹(通过枪传递)
        //--玩家子弹到达目标时根据部位伤害敌人


    }
}
