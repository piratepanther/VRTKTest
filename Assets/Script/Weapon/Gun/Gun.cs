using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Script.Common;
using Common;

namespace Assets.Script.Weapon
{
    [RequireComponent(typeof(MuzzleFlash))]
    public class Gun:MonoBehaviour
    {
        private GameObject bulletPrefab;
        [Tooltip("子弹名称")]
        public string bulletName;
        [Tooltip("枪口名称")]
        public string firePoint;
        [Tooltip("动画片段名称")]
        public string fireAnimName="Fire";
        [Tooltip("枪攻击力")]
        public float atk;
        [HideInInspector]
        public Transform firePointTF;//枪口
        private AudioSource audioSource;
        private MuzzleFlash flash;

        private void Start()
        {
            bulletPrefab = ResourcesManager.Load<GameObject>(bulletName);
            firePointTF = transform.FindChildByName(firePoint);
            audioSource = GetComponent<AudioSource>();
            flash=GetComponent<MuzzleFlash>();

        }


        public void Fire(Vector3 direction)
        {
            GameObject bulletGO = GameObjectPool.instance.CreateObject(bulletName, bulletPrefab, firePointTF.position, Quaternion.LookRotation(direction));
            bulletGO.GetComponent<Bullet>().atk=this.atk;


            audioSource.Play();
            flash.Display();


        }
    }
}
