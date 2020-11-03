using SkillSystem.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Common;

public class CharacterInputController : MonoBehaviour
{
    private Button[] skillButtons;
    private CharacterSkillSystem skillSystem;
    private Animator anim;
    private PlayerStatus status;

    // Start is called before the first frame update
    void Awake()
    {
        skillButtons = GetComponents<Button>();
        skillSystem = GetComponent<CharacterSkillSystem>();
        anim = GetComponentInChildren<Animator>();
        status = GetComponent<PlayerStatus>();

    }
    private void OnEnable()
    {
        //注册事件
        //         joystick.onMove.AddListener(OnJoystickMove);
        //         joystick.onMoveStart.AddListener(OnJoystickMoveStart);
        //         joystick.onMoveEnd.AddListener(OnJoystickMoveEnd);
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].onClick.AddListener(OnSkillButtonDown);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnSkillButtonDown()
    {
        //         CharacterSkillManager SkillManager = GetComponent<CharacterSkillManager>();
        //         SkillData data = SkillManager.PrepareSkill(1002);
        //         if (data != null)
        //         {
        //             SkillManager.GenerateSkill(data);
        //         }
        
        //1.如果正在攻击则退出
        if (IsAttacking()) return;
        //2.队列queue
        int id = 1002;
        skillSystem.AttackUseSkill(id);
    }

    private void OnDisable()
    {
        //注销事件
//         joystick.onMove.RemoveListener(OnJoystickMove);
//         joystick.onMoveStart.RemoveListener(OnJoystickMoveStartl;
//         joystick.onMoveEnd.RemoveListener(OnJoystickMoveEnd);
        for (int i=0; i < skillButtons.Length; i++)
        {
            skillButtons[i].onClick.RemoveListener(OnSkillButtonDown);
        }
        
    }
    private bool IsAttacking()
    {
       return anim.GetBool(status.chParams.Attack01) || anim.GetBool(status.chParams.Attack02) ||
            anim.GetBool(status.chParams.Attack03);
    }

}
