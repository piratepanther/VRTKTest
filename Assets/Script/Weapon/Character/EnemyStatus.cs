using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Common;

namespace Assets.Script.Weapon
{
	[Serializable]
	public class EnemyStatus : CharacterStatus
	{
        [Tooltip("动画参数")]
        public CharacterAnimationParameter chParams;

        protected override void Death()
        {
            GetComponentInChildren<Animator>().SetBool(chParams.Death, true);
            //Destroy(gameObject, 10);
            GameObjectPool.instance.CollectObject(gameObject,10);
        }
	
	}
}
