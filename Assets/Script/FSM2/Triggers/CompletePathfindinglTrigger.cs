
namespace Assets.Script.FSM2
{
    class CompletePathfindingTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {

            return fsm.IsPathFindingComplete;

        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.CompletePathfinding;
        }
    }
}
