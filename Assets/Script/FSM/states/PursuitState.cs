using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    class PursuitState : FSMState
    {
        public override void Init()
        {
            StateID=FSMStateID.Pursuit;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsm.anim.SetBool(fsm.chStates.chParams.run, true);

        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            //fsm.targetTF
            fsm.MoveToTarget(fsm.targetTF.position, fsm.chStates.attackDistance, fsm.runSpeed);
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.StopMove();
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.chStates.chParams.run, false);
        }
    }
}
