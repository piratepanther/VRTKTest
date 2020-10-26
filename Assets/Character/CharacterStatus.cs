using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    [Tooltip("动画参数")]
    public CharacterAnimationParameter chParams;
    [Tooltip("血量")]
    public float HP;
    [Tooltip("品大血量")]
    public float maxHP;
    [Tooltip("法力")]
    public float SP;
    [Tooltip("最大去力")]
    public float maxSP;
    [Tooltip("基础攻击力")]
    public float baseATK;
    [Tooltip("防御力")]
    public float defence;
    [Tooltip("攻击间际")]
    public float attacklnterval;
    [Tooltip("攻击距离")]
    public float attackDistance;

}
