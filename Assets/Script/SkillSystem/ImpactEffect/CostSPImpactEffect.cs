using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Common;
using Assets.Script.SkillSystem;

namespace Assets.Script.SkillSystem
{
    class CostSPImpactEffect:IimpactEffect
    {     
        public void Execute(SkillDeployer skillDeployer)
        {
            var status = skillDeployer.SkillData.owner.GetComponent<PlayerStatus>();
            status.SP -= skillDeployer.SkillData.costSP;
        }
    }
}
