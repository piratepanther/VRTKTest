using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    class CompletePatrolTrigger : FSMTrigger
    {
        public override bool HandlerTrigger(FSMBase fsm)
        {

            return fsm.IspatrolComplete;

        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.CompletePatrol;
        }
    }
}
