using UnityEngine;
using System.Collections;
using SkillSystem.Common;

namespace Common
{
	/// <summary>
	/// 技能释放器
	/// </summary>
    public class SkillDeployer : MonoBehaviour
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
        //初始化释放器
        private void InitDeployer()
        {
            //创建算法对象
            //选区

            //skillData.selectorType 反射实现

            //影响



        }


        //执行算法对象



        //释放方式

	    
	}
}
