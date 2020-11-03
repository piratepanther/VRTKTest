using UnityEngine;
using System.Collections;
using SkillSystem.Common;
using System;
using Assets.Script.SkillSystem;

namespace Common
{
	/// <summary>
	/// 技能释放器
	/// </summary>
    public abstract class SkillDeployer : MonoBehaviour
	{
	    private SkillData skillData;
        public SkillData SkillData
        {
            get
            {
                return skillData;
            }
            set
            {
                skillData = value;
                //创建算法对象
                InitDeployer();
            }
        }

        private IAttackSelector selector;
        private IimpactEffect[] impactArray;
        //初始化释放器
        private void InitDeployer()
        {
            //创建算法对象
            //命名规则：SkillSystem.Common.+枚举名AttackSelector
            //skillData.selectorType 反射实现
            //1.选区
            selector = DeployerConfigFactory.CreatAttackSelector(skillData);

            //2.影响
            //命名规则：SkillSystem.Common.+skillData.impactType[i]+Impact
            impactArray = DeployerConfigFactory.CreatImpactEffects(skillData);

        }
        //执行算法对象
        //选区
        public void CalculateTarget()
        {
            skillData.attackTargets = selector.SelectTarget(skillData, transform);


        }

        //影响
        public void ImpactTarget()
        {
            for (int i = 0; i < impactArray.Length; i++)
            {
                impactArray[i].Execute(this);

            }

        }       
        //释放方式
        public abstract void DeploySkill();//由子类实现，定义具体释放策略
        	    
	}
}
