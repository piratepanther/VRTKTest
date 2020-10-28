using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSystem.Common;
using UnityEngine;
using Common;

namespace Assets.Script.SkillSystem
{
    /// <summary>
    /// 影响效果算法接口
    /// </summary>
    interface IimpactEffect
    {
        //伤害生命  5 secends
        void Execute(SkillDeployer skillDeployer);


    }
}
