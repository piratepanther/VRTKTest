using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;


public class SingleGunControl : MonoBehaviour
{
    private VRTK_ControllerEvents controller;

    private void OnEnable()
    {
        controller = GetComponentInParent<VRTK_ControllerEvents>();
        if (controller == null)
        {
            this.enabled = false;
            return;
        }
        controller.TriggerPressed += OnTriggerPressed;
    }
    private void OnDisable()
    {
        if (controller == null)
        {
           return;
        }
        controller.TriggerPressed -= OnTriggerPressed;
    }

    private void OnTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        throw new System.NotImplementedException();
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
