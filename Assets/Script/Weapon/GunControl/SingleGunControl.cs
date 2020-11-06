using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;
using Common;


namespace Assets.Script.Weapon
{
    [RequireComponent(typeof(Gun))]
	public class SingleGunControl : MonoBehaviour
	{
	    private VRTK_ControllerEvents controller;
        private Gun gunAction;
        private Animator anim;
        

	
	    
	    private void OnEnable()
	    {
            controller = GetComponentInParent<VRTK_ControllerEvents>();
            
            if (controller == null)
	        {
	            this.enabled = false;
	            return;
	        }
            gunAction = GetComponent<Gun>();
            anim = GetComponentInChildren<Animator>();
            GetComponentInChildren<AnimationEventBehaviour>().attackHandler += OnFiring;
	        controller.TriggerPressed += OnTriggerPressed;
	    }

        private void OnFiring()
        {
            gunAction.Fire(gunAction.firePointTF.forward);


        }


	    private void OnDisable()
	    {
	        if (controller == null)
	        {
	           return;
	        }
	        controller.TriggerPressed -= OnTriggerPressed;
	    }

        [Tooltip("最小发射间隔")]
        public float minFireInterval=0.5f;//可以放在枪上，比fire动画时间长才行
        private float lastPressedTime;
	
	    private void OnTriggerPressed(object sender, ControllerInteractionEventArgs e)
	    {
	        if(Time.time-lastPressedTime<minFireInterval)return;            
            
            /*throw new System.NotImplementedException();*/
            anim.SetBool(gunAction.fireAnimName, true);

            lastPressedTime=Time.time;

	    }
	    
	    // Start is called before the first frame update
	    void Start()
	    {
	
	    }
	
	   
	    // Update is called once per frame
	    void Update()
	    {
// 	        if(controller.triggerPressed)
//             {
//                 //连续发射
//             }


	    }
	}
}
