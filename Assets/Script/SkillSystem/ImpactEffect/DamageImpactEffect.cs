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
        //private SkillData skilldata;
        public void Execute(SkillDeployer skillDeployer)
        {
            //skilldata = skillDeployer.SkillData;
            skillDeployer.StartCoroutine(RepeatDamage(skillDeployer));
        }

        //重复伤害
        //private IEnumerator RepeatDamage(SkillDeployer skillDeployer)
        private IEnumerator RepeatDamage(SkillDeployer skillDeployer)
        {
            float atkTime=0;
            do 
            {
                OnceDamage(skillDeployer.SkillData);
                yield return new WaitForSeconds(skillDeployer.SkillData.atkInterval);
                atkTime+= skillDeployer.SkillData.atkInterval;
                skillDeployer.CalculateTarget();//重新计算目标
            } while (atkTime< skillDeployer.SkillData.durationTime);


        }
        //单次伤害
        private void OnceDamage(SkillData skillData)
        {
            for (int i = 0; i < skillData.attackTargets.Length; i++)
            {
                float atk = skillData.atkRatio* skillData.owner.GetComponent<PlayerStatus>().baseATK;
                var status = skillData.attackTargets[i].GetComponent<CharacterStatus>();
                status.Damage(atk);
          
            }
            //加载攻击特效
        }
    }
}
