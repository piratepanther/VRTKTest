using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class EnemyStatus : CharacterStatus
{
    [Tooltip("攻击间际")]
    public new float attacklnterval=5;



}
