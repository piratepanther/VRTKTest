using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    public class NoHealthTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
            return fsm.chStates.HP <= 0;
            
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }
    }
}
