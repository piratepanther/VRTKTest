using SkillSystem.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Common;
/// <summary>
/// 技能管理器
/// </summary>
public class CharacterSkillManager : MonoBehaviour
{
    public SkillData[] skillDatas;

    private void Start()
    {
        for (int i = 0; i < skillDatas.Length; i++)
        {
            InitSkill(skillDatas[i]);
        }
    }
    /// <summary>
    /// 技能初始化
    /// </summary>
    /// <param name="skillData"></param>
    private void InitSkill(SkillData skillData)
    {

        /*
         资源映射表
         * 资源名称                        资源路径
         * BaseMeleeAttackSkill             Skill/BaseMeleeAttackSkill
        
         */


        skillData.skillPrefab = Resources.Load<GameObject>("Skill/" + skillData.prefabName);

       skillData.owner = gameObject;

    }
     //<summary>
     //技能释放条件:冷却  法力
     //</summary>
     //<param name="id"></param>
     //<returns></returns>
    public SkillData PrepareSkill(int id)
    {
        //查找技能数据,判断条件,返回数据
        SkillData data = skillDatas.Find(s => s.skillID == id);

        float sp = GetComponent<CharacterStatus>().SP;
        if(data != null && data.coolRemain <= 0 && data.costSP<=sp)
        {
            return data;
        }
        return null;

    }
    /// <summary>
    /// 技能生成
    /// </summary>
    public void GenerateSkill(SkillData skillData)
    {
        //创建预制件
        GameObject skillGo = Instantiate(skillData.skillPrefab, transform.position, transform.rotation);
        //销毁技能
        Destroy(skillGo, skillData.durationTime);
        //冷却技能
        StartCoroutine(CoolTimeDown(skillData));

    }
    /// <summary>
    /// 技能冷却
    /// </summary>
    /// <param name="skillData"></param>
    /// <returns></returns>
    private IEnumerator CoolTimeDown(SkillData skillData)
    {
        skillData.coolRemain=skillData.coolTime;
        while (skillData.coolRemain > 0) {
            yield return new WaitForSeconds(1);
            skillData.coolRemain--;
        }
    }

    public static implicit operator CharacterSkillManager(SkillData v)
    {
        throw new NotImplementedException();
    }
}
