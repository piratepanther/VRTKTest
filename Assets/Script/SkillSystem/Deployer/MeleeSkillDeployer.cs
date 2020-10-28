using UnityEngine;
using System.Collections;

namespace Common
{
    /// <summary>
    /// 近身释放器
    /// </summary>
	public class MeleeSkillDeployer : SkillDeployer
	{
        public override void DeploySkill()
        {
            //执行选区算法
            CalculateTarget();
            

            //执行影响算法
            ImpactTarget();

        }
    }
}
