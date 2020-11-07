
namespace Assets.Script.FSM2
{
    class KilledTargetTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
           return fsm.targetTF.HP <= 0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.killedTarget;
        }
    }
}
