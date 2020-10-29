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

    // Start is called before the first frame update
    void Awake()
    {
        skillButtons = GetComponents<Button>();
        skillSystem = GetComponent<CharacterSkillSystem>();

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


}
