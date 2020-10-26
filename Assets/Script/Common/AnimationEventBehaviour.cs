using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common { 
    public class AnimationEventBehaviour : MonoBehaviour
    {
        private Animator anim;
        public event Action attackHandler;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void OnCancelAnim(string animParam)
        {
            anim.SetBool(animParam, false);
        }

        // Update is called once per frame
        private void OnAttack()
        {
            if (attackHandler != null)
            {
                attackHandler();
            }
        }
    }
}