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

    /// <summary>
    /// 枪口火光
    /// </summary>
    class MuzzleFlash:MonoBehaviour
    {
        [Tooltip("火光特效")]
        public string flashGoName = "";
        private GameObject flashGO;
        private float hideTime;
        [Tooltip("持续实现")]
        public float displayTime=0.5f;

        private void Start()
        {
            flashGO = transform.FindChildByName(flashGoName).gameObject;
        }
        
        public void Display()
        {
            flashGO.SetActive(true);
            hideTime = Time.time + displayTime;

        }

        public void Update()
        {
            if (hideTime <= Time.time)
            {
                flashGO.SetActive(false);
                enabled = false;
            }
        }
    }
}
