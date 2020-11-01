using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    class KilledTargetTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
           return fsm.targetTF.GetComponent<CharacterStatus>().HP <= 0;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.killedTarget;
        }
    }
}
