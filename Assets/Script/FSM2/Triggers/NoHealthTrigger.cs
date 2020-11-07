
namespace Assets.Script.FSM2
{
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
            return fsm.enemyStates.HP <= 0;
            
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }
    }
}
