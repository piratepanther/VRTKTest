using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SkillSystem.Common;
using Assets.Script.SkillSystem;


namespace Assets.Script.Common
{
    class SectorAttackSelector:IAttackSelector
    {

        public Transform[] SelectTarget(SkillData skillData, Transform skillTF)
        {
            //string[] skillData.attackTargetTags  string[]-->Transform[]
            List<Transform> targets = new List<Transform>();
            for (int i = 0; i < skillData.attackTargetTags.Length; i++)
            {
                GameObject[] tempGoArray = GameObject.FindGameObjectsWithTag(skillData.attackTargetTags[i]);
                targets.AddRange(tempGoArray.Select(g => g.transform));
            }                       
            //判断攻击范围

            targets.FindAll(t => 
                Vector3.Distance(t.position, skillTF.position)<=skillData.attackDistance
                && Vector3.Angle(skillTF.forward, t.position - skillTF.position)<=skillData.attackAngle/2
            );

            //筛选出活的角色
            targets = targets.FindAll(t => t.GetComponent<CharacterStatus>().HP>=0);
            
            //单攻群攻
            Transform[] result = targets.ToArray();
            if (skillData.attackType == SkillAttackType.Group || result.Length==0)
            {
                return result;
            }
            else
            {
                //距离最近的敌人
                Transform min = result.GetMin(t => Vector3.Distance(t.position, skillTF.position));
                return new Transform[]{min};
            }            
        }
    }
}
