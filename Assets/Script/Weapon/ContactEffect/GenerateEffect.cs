using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Common;
using Common;
using System.Threading.Tasks;

namespace Assets.Script.Weapon
{

    
    class GenerateEffect:MonoBehaviour
    {
        private Bullet bullet;
        private void Awake()
        {
            bullet = GetComponent<Bullet>();

        }

        private void OnEnable()
        {
            bullet.ArrivedTargetPoint += CreatEffect;

        }

        private void OnDisable()
        {
            bullet.ArrivedTargetPoint -= CreatEffect;

        }
        private void CreatEffect(object sender, BulletArrivedEventArgs e)
        {
            //根据不同物体 生成不同特效
            //args.Hit.collider.gameoject
//             switch (e.Hit.collider.tag)
//             {
//                 case"":
//                     break;
//             }
            //自定义规则，特效命名规则：合理利用资源名称
            //Effect+物体标签tag
            if (e.Hit.collider == null) return;
            string prefabName = "Effect" + e.Hit.collider.tag;
            GameObject prefab = ResourcesManager.Load<GameObject>(prefabName);
            if (prefab == null) return;
            //朝向法线方向，向法线方向移动一点
            GameObjectPool.instance.CreateObject(prefabName, prefab, e.Hit.point + e.Hit.normal*0.01f, Quaternion.LookRotation(e.Hit.normal));

        }

//         private void CreatEffect(BulletArrivedEventArgs args)
//         {
//             //根据不同物体 生成不同特效
//             //args.Hit.collider.gameoject
// 
// 
// 
//         }

    }
}
