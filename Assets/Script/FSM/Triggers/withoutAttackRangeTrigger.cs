
using UnityEngine;

namespace Assets.Script.FSM
{
    class WithoutAttackRangeTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {

            return Vector3.Distance(fsm.transform.position, fsm.targetTF.position) > fsm.chStates.attackDistance; ;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.withoutAttackRange;
        }
    }
}
