using Common;
using System;
using UnityEngine;

namespace Assets.Script.FSM2
{
    class AttackingState : FSMState
    {
        private FSMBase fsmBase;
        
        public override void Init()
        {
            StateID = FSMStateID.Attacking;
        }
        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsmBase = fsm;

            fsm.anim.GetComponent<AnimationEventBehaviour>().attackHandler += OnFire;


        }

        private void OnFire()
        {
            //枪口指向玩家头部
            Vector3 dir = Camera.main.transform.position - fsmBase.gunAction.firePointTF.position;
            fsmBase.gunAction.Fire(dir);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.anim.GetComponent<AnimationEventBehaviour>().attackHandler -= OnFire;
        }
        

        private float atkTime;

        private void LookAt(FSMBase fsm)
        {
            Vector3 position = fsm.player.transform.position;
            position.y = fsm.transform.position.y;
            fsm.transform.LookAtPosition(position, fsm.rotateSpeed);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            if (atkTime <= Time.time)
            {
                fsm.anim.SetBool(fsm.enemyStates.chParams.Attack01,true);
                //fsm.skillSystem.UseRandomSkill();
                atkTime = Time.time + fsm.enemyStates.attacklnterval;

            }

            LookAt(fsm);


        }
    }
}
