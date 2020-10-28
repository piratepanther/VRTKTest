using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillSystem.Common;
using UnityEngine;


namespace Assets.Script.SkillSystem
{
    /// <summary>
    /// 攻击选区
    /// </summary>
    interface IAttackSelector
    {
        /// <summary>
        /// 搜索目标
        /// </summary>
        /// <param name="skillData">技能数据</param>
        /// <param name="skillTF">技能所在物体</param>
        /// <returns></returns>
        Transform[] SelectTarget(SkillData skillData,Transform skillTF);
    }
}
