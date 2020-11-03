using UnityEngine;
using System.Collections;
using Assets.Script.Common;
using Common;

namespace Assets.Script.Weapon
{
	public class AutoColletObject : MonoBehaviour
	{
	    
	    [Tooltip("回收延时时间")]
	    public float delayTime = 3;
	    
	    private void Start()
	    {
	        GameObjectPool.instance.CollectObject(gameObject,delayTime)
	
	
	    }
	    
	}
}
