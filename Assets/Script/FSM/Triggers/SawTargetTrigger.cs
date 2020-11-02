using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    class SawTargetTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {
            return fsm.targetTF!=null;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.SawTarget;
        }
    }
}
