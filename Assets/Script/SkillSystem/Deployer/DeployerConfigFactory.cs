using SkillSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.SkillSystem
{
    class DeployerConfigFactory
    {
        private static Dictionary<string,object> cache;

        static DeployerConfigFactory()
        {
            cache = new Dictionary<string,object>();
        }
        
        //命名规则：SkillSystem.Common.+枚举名AttackSelector
        public static IAttackSelector CreatAttackSelector(SkillData skillData)
        {
            string className = string.Format("SkillSystem.Common.{0}AttackSelector", skillData.selectorType);
            return CreatObject<IAttackSelector>(className);                        
        }
        //命名规则：SkillSystem.Common.+skillData.impactType[i]+Impact
        public static IimpactEffect[] CreatImpactEffects(SkillData skillData)
        {
            IimpactEffect[] impactArray = new IimpactEffect[skillData.impactType.Length];
            for (int i = 0; i < skillData.impactType.Length; i++)
            {
                string classNameImpact = string.Format("SkillSystem.Common.{0}ImpactEffect", skillData.impactType[i]);

                impactArray[i] = CreatObject<IimpactEffect>(classNameImpact);

            }
            return impactArray;
        }

        private static T CreatObject<T>(string className) where T : class
        {
            if (!cache.ContainsKey(className))
            {
                Type type = Type.GetType(className);
                object instance = Activator.CreateInstance(type);
                cache.Add(className, instance);
            }
            return cache[className] as T;
        }

    }
}
