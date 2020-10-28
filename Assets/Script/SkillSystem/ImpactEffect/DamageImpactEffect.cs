using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using UnityEngine;
using SkillSystem.Common;

namespace Assets.Script.SkillSystem
{
    class DamageImpactEffect:IimpactEffect
    {
        private SkillData skilldata;
        public void Execute(SkillDeployer skillDeployer)
        {
            skilldata = skillDeployer.SkillData;
            skillDeployer.StartCoroutine(RepeatDamage());
        }
        //重复伤害
        private IEnumerator RepeatDamage(SkillDeployer skillDeployer)
        {
            float atkTime=0;
            do 
            {
                OnceDamage();
                yield return new WaitForSeconds(skilldata.atkInterval);
                atkTime+=skilldata.atkInterval;
                skillDeployer.CalculateTarget();//重新计算目标
            } while (atkTime<skilldata.durationTime);


        }
        //单次伤害
        private void OnceDamage()
        {
            for (int i = 0; i < skilldata.attackTargets.Length; i++)
            {
                float atk = skilldata.atkRatio*skilldata.owner.GetComponent<PlayerStatus>().baseATK;
                var status = skilldata.attackTargets[i].GetComponent<CharacterStatus>();
                status.Damage(atk);
          
            }
            //加载攻击特效
        }
    }
}
