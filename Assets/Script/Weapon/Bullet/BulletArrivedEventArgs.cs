using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Weapon
{
    /// <summary>
    /// 子弹到达目标，事件参数类
    /// </summary>
    public class BulletArrivedEventArgs
    {

        public RaycastHit Hit { get; set; }

    }
}
