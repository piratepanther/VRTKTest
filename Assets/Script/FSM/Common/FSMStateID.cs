using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.FSM
{
    public enum FSMStateID
    {
        /// <summary>
        ///不存在该状态
        ///<summary>
        None,
        /// <summary>
        ///默认
        Default,
        /// <summary>
        /// 死亡
        Dead,
        ///<summary>
        ///闭置
        Idel,
        ///追逐
        ///</ summary>
        Pursuit,
        ///<summary>
        ///攻击
        Attacking,
        ///<summary>
        ///巡逻
        /// </ summary>
        Patrolling
    }
}
