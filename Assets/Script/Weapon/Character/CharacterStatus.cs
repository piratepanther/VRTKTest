using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Script.Weapon
{
	[Serializable]
	public abstract class CharacterStatus : MonoBehaviour
	{
	    
	    [Tooltip("血量")]
	    public float HP;
	    [Tooltip("品大血量")]
	    public float maxHP;
// 	    [Tooltip("法力")]
// 	    public float SP;
// 	    [Tooltip("最大去力")]
// 	    public float maxSP;
// 	    [Tooltip("基础攻击力")]
// 	    public float baseATK;
	    [Tooltip("防御力")]
	    public float defence;
// 	    [Tooltip("攻击间际")]
// 	    public float attacklnterval;
// 	    [Tooltip("攻击距离")]
// 	    public float attackDistance;
	

	    public void Damage(float val)
	    {
	        val -= defence;
	        if (HP - val > 0)
	        {
	            HP -= val;
	        }
	        else
	        {
	            Death();
	        }
	        
	    }
        protected abstract void Death();
	
// 	    protected virtual void Death()
//         {
//             GetComponentInChildren<Animator>().SetBool(chParams.Death, true);
//        	
	}
}
