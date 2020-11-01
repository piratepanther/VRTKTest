using UnityEngine;

namespace Assets.Script.FSM
{
    class ReachTargetTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
            if (fsm.targetTF == null) return false;
            
            return Vector3.Distance(fsm.transform.position, fsm.targetTF.position)<=fsm.chStates.attackDistance;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.ReachTarget;
        }
    }
}
