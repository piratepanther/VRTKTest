using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.FSM
{
    class AttackingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Attacking;
        }


        private float atkTime;
        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            if (atkTime <= Time.time)
            {
                fsm.skillSystem.UseRandomSkill();
                atkTime = Time.time + fsm.chStates.attacklnterval;

            }
        }
    }
}
