
namespace Assets.Script.FSM2
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
