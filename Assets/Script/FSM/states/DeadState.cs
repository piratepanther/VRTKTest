using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM.states
{
    class DeadState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Dead;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //fsm.anim.SetBool(fsm.chStates.chParams.Death, true);
            fsm.enabled = false;
        }

        

    }
}
