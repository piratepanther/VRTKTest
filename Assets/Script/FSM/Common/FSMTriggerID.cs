using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    public enum FSMTriggerID
    {
        /// <_summary>
        /// 没有生命
        NoHealth,
        ///<summary>
        ///发现目行
        SawTarget,
        /// <summary:>
        /// 到达目杯
        /// <summary>
        ReachTarget,
        /// <summary>
        ///目标被击杀
        ///<summary>
        killedTarget,
        ///<summary>
        ///超出攻击范围
        ///</summary>
        withoutAttackRange,
        ///<summary>
        ///丢失目标
        ///<summary>
        LoseTarget,
        ///<summary>
        ///完成巡逻
        ///</summary>
        CompletePatrol
    }
}
