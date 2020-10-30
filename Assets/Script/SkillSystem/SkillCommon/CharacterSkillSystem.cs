using UnityEngine;
using System.Collections;
using Assets.Script.Common;
using SkillSystem.Common;
using Assets.Script.Common;
namespace Common
{
    [RequireComponent(typeof(CharacterSkillManager))]
	public class CharacterSkillSystem : MonoBehaviour
	{
        private CharacterSkillManager skillManager;
        private Animator animator;
        private SkillData skillData;
        public Transform selectedTarget;
        private void start()
        {
            skillManager = GetComponent<CharacterSkillManager>();
            animator = GetComponentInChildren<Animator>();
            GetComponentInChildren<AnimationEventBehaviour>().attackHandler += DeploySkill;
        }

        private void DeploySkill()
        {
            skillManager.GenerateSkill(skillData);
        }
        
               
        /// <summary>
        /// 玩家技能
        /// </summary>
        public void AttackUseSkill(int skillID)
        {
        //准备技能
            skillData = skillManager.PrepareSkill(skillID);
            if (skillData == null) return;

        //播放动画
            animator.SetBool(skillData.animationName, true);

        //生成技能 DeploySkill()//动画播放自动委托释放
        //如果单攻
            if (skillData.attackType != SkillAttackType.Single) return;
            
            //--查找目标
                Transform targetTF = SelectTarget(skillData, transform);

            //--朝向目标
                transform.LookAt(targetTF);

            //--选中目标
            //1.指定时间后取消
                SetSelectedActiveFx(false);
                selectedTarget = targetTF;

            //2.选择A目标，在自动取消前，又选中B，则取消A
                SetSelectedActiveFx(true);

        }        

        private void SetSelectedActiveFx(bool state)
        {
            if (selectedTarget == null) return;
            var selected = selectedTarget.GetComponent<CharacterSelected>();
            if (selected)
            {
                selected.SetSelectedActive(state);
            }
        }

        private Transform SelectTarget(SkillData skillData,Transform transform)
        {
            Transform[] target = new SectorAttackSelector().SelectTarget(skillData, transform);
                        
            return target.Length!=0? target[0]:null;
        }
        
        /// <summary>
        /// 随机技能（NPC攻击）
        /// </summary>
        public void UseRandomSkill()
        {
            //需求从管理器中挑选随机技能
            //--先筛选出可以释放的技能再产生随机数
            var usableSkills = skillManager.skillDatas.FindAll(s => skillManager.PrepareSkill(s.skillID) != null);
            if (usableSkills.Length == 0) return;
            int index = Random.Range(0, usableSkills.Length);
            AttackUseSkill(usableSkills[index].skillID);
        }
	}
}
