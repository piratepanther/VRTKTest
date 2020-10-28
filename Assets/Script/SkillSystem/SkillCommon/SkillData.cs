using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillSystem.Common
{

    [Serializable]
    public class SkillData
    {
        public int skillID;
        public string name;
        public string description;
        public int coolTime;
        public int coolRemain;
        public int costSP;
        public float attackDistance;
        public float attackAngle;
        public string[] attackTargetTags = { "Enemy" };
        [HideInInspector]
        public Transform[] attackTargets;
        public string[] impactType = { "CostSP", "Damage" };//反射创建
        public int nextBatterId;
        public float atkRatio;
        public float durationTime;
        public float atkInterval;//配合durationTime计算多少次伤害
        //技能所属
        [HideInInspector]
        public GameObject owner;

        //<summary>技能预制件名称</summary>
        public string prefabName;

        //<summary> 预制件对象</summary>
        [HideInInspector]
        public GameObject skillPrefab;

        //<summary> 动画名称</summary>
        public string animationName;
        //<summary>受击特效名称</summary>
        public string hitFxName;
        //<summary>受击特效预制件</summary>

        [HideInInspector]
        public GameObject hitFxPrefab;

        //<summary>技能等级</summary>
        public int level;
        //<summary>攻击类型单攻，群攻</summary>
        public SkillAttackType attackType;
        //<summary>选择类型扇形（圆形），矩形</summary>
        public SelectorType selectorType;


    }
}