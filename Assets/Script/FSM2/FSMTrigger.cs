using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Script.FSM2
{
    public abstract class FSMTrigger
    {        
        //编号枚举属性

        public FSMTriggerID TriggerID { get; set; }

        public FSMTrigger() 
        {
            Init();
        }

        public abstract void Init();

        //逻辑处理

        public abstract bool HandlerTrigger(FSMBase fsm);
    }
}
