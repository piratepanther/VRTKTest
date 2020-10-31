using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.FSM
{
    public abstract class FSMState
    {
        public FSMStateID StateID { get; set; }
        private List<FSMTrigger> Triggers;
        /// <summary>
        /// 映射表
        /// </summary>
        private Dictionary<FSMTriggerID, FSMStateID> map;
        public FSMState()
        {
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            Init();
        }

        /// <summary>
        /// 检测当前状态是否满足
        /// </summary>
        public void Reason(FSMBase fsm)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i].HandlerTrigger(fsm))
                {
                    //从映射表中获取输出状态
                    FSMStateID StateID = map[Triggers[i].TriggerID];
                    //切换状态
                    fsm.ChangeActiveState(StateID);
                    return;
                }
            }
        }

        public abstract void Init();

        //状态机调用
        public void AddMap(FSMTriggerID triggerID, FSMStateID stateID)
        {
            map.Add(triggerID, stateID);
            CreatTrigger(triggerID);
        }

        private void CreatTrigger(FSMTriggerID triggerID)
        {
            //创建条件对象
            //命名规范"Assets.Script.FSM." + triggerID + "Trigger"
            Type type = Type.GetType("Assets.Script.FSM." + triggerID + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            Triggers.Add(trigger);
        }
        //为具体状态类提供可选事件
        public virtual void EnterState(FSMBase fsm) { }
        public virtual void ActionState(FSMBase fsm) { }
        public virtual void ExitState(FSMBase fsm) { }
        


    }
}
