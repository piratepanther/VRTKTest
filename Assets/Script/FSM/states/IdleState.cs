using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.FSM
{
    class IdleState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Idel;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsm.anim.SetBool(fsm.chStates.chParams.Idle,true);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.chStates.chParams.Idle, false);
        }



    }
}
