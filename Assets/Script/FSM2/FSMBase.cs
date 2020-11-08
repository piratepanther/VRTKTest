using UnityEngine;
using System.Collections.Generic;
using System;
using Assets.Script.Common;
using SkillSystem.Common;
using UnityEngine.AI;
using Common;
using Assets.Script.Weapon;

namespace Assets.Script.FSM2
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        #region Unity生命周期
        private void Start()
        {
            InitComponent();
            ConfigFSM();
            InitDefaultState();

        }

        internal void MoveToTarget(Vector3 position, float attackDistance, object moveSpeed)
        {
            throw new NotImplementedException();
        }

        public FSMStateID test_CurrentStateID;


        //每帧处理的逻辑
        public void Update()
        {
            test_CurrentStateID = currentState.StateID;


            //判断当前状态条件
            currentState.Reason(this);

            //执行当前逻辑
            currentState.ActionState(this);

            //搜索目标
            //SearchTarget();
        }
        #endregion

        #region 状态机自身成员

        //状态列表，状态机自身成员
        private List<FSMState> states;
        [Tooltip("默认状态编号")]
        public FSMStateID defaultStateID;
        //public FSMState currentState;
        //[SerializeField]//将私有字段在编译器中显示
        private FSMState currentState;
        private FSMState defaultState;
        [Tooltip("当前状态机配置文件")]
        public string fileName="AI_02.txt";

        [HideInInspector]
        public CharacterSkillSystem skillSystem;
        [Tooltip("路点")]
        public Vector3[] wayPoints;
       
        [HideInInspector]
        public bool IsPathFindingComplete;
        [HideInInspector]
        public Gun gunAction;


        private void InitDefaultState()
        {
            defaultState = states.Find(s => s.StateID == defaultStateID);
            currentState = defaultState;

            //进入状态
            currentState.EnterState(this);
        }

        //配置状态机
        private void ConfigFSM()
        {
            states = new List<FSMState>();
            var map = AIConfigurationReaderFactory.GetMap(fileName);

            foreach (var state in map)
            {
                Type type = Type.GetType("Assets.Script.FSM." + state.Key + "State");
                FSMState stateObj = Activator.CreateInstance(type) as FSMState;
                states.Add(stateObj);
                foreach (var dic in state.Value)
                {
                    FSMTriggerID triggerID = (FSMTriggerID)Enum.Parse(typeof(FSMTriggerID),dic.Key);
                    FSMStateID stateID = (FSMStateID)Enum.Parse(typeof(FSMStateID), dic.Value);
                    stateObj.AddMap(triggerID, stateID);
                }
            }

        }

//         private void ConfigFSM()//硬编码
//         {
//             states = new List<FSMState>();
//             //--创建状态对象(反射)
//             IdleState Idle = new IdleState();
//             //--设置状态（AddMap）
//             Idle.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
//             Idle.AddMap(FSMTriggerID.SawTarget, FSMStateID.Pursuit);
//             states.Add(Idle);
// 
//             //--创建状态对象
//             DeadState dead = new DeadState();
//             //--设置状态（AddMap
//             states.Add(dead);
// 
//             PursuitState pursuit = new PursuitState();
//             pursuit.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
//             pursuit.AddMap(FSMTriggerID.ReachTarget, FSMStateID.Attacking);
//             pursuit.AddMap(FSMTriggerID.LoseTarget, FSMStateID.Default);
//             states.Add(pursuit);
// 
//             AttackingState attacking = new AttackingState();
//             attacking.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
//             attacking.AddMap(FSMTriggerID.withoutAttackRange, FSMStateID.Pursuit);
//             attacking.AddMap(FSMTriggerID.killedTarget, FSMStateID.Default);
//             states.Add(attacking);
// 
//             PatrollingState patrolling = new PatrollingState();
//             patrolling.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
//             patrolling.AddMap(FSMTriggerID.SawTarget, FSMStateID.Pursuit);
//             patrolling.AddMap(FSMTriggerID.CompletePatrol, FSMStateID.Idel);
//             states.Add(patrolling);
// 
//         }


        //切换状态
        public void ChangeActiveState(FSMStateID stateID)
        {
            //离开上一个状态
            currentState.ExitState(this);
            
            //currentState = ?设置当前状态
            if (stateID == FSMStateID.Default)
                currentState = defaultState;
            else
                currentState = states.Find(s => s.StateID == stateID);
            //进入下一个状态
            currentState.EnterState(this);
        }

        #endregion

        #region 为状态与条件提供的成员

        //为状态与条件提供的成员
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public EnemyStatus enemyStates;

        public void InitComponent()
        {
            anim = GetComponentInChildren<Animator>();
            enemyStates = (EnemyStatus)GetComponent<CharacterStatus>();
            //             navAgent = GetComponent<NavMeshAgent>();
            //             skillSystem = GetComponent<CharacterSkillSystem>();

            gunAction = GetComponent<Gun>();
            player = FindObjectOfType<PlayerStatus>();

        }
        [HideInInspector]
        public PlayerStatus player;
        [Tooltip("攻击目标标签")]
        public string[] targetTags= {"Player"};
        [Tooltip("视野距离")]
        public float sightDistance = 10;
        //查找目标(目前复用技能系统里的查找目标)
//         private void SearchTarget()
//         {
//             SkillData skilldata = new SkillData()
//             {
//                 attackTargetTags = targetTags,
//                 attackDistance = sightDistance,
//                 attackAngle=360,
//                 attackType = SkillAttackType.Single
// 
//             };
//             Transform[] targetArr = new SectorAttackSelector().SelectTarget(skilldata,transform);
// 
//             targetTF = targetArr.Length==0?null:targetArr[0];
// 
//         }

        private UnityEngine.AI.NavMeshAgent navAgent;
        [Tooltip("旋转速度")]
        public float rotateSpeed = 20;
        [Tooltip("跑步速度")]
        public float runSpeed=2;
//         [Tooltip("走路速度")]
//         public float walkSpeed=1;

        /// <summary>
        /// navAgent
        /// </summary>
        /// <param name="position"></param>
        /// <param name="stopDistance"></param>
        /// <param name="moveSpeed"></param>
//         public void MoveToTarget(Vector3 position,float stopDistance,float moveSpeed)
//         {
//             //通过寻路组件实现
//             navAgent.SetDestination(position);
//             navAgent.stoppingDistance = stopDistance;
//             navAgent.speed = moveSpeed;
// 
//         }
//  
//         public void StopMove()
//         {
//             navAgent.SetDestination(transform.position);
//             //navAgent.enabled = false; navAgent.enabled = true;
//         }



        #endregion
        /*
         执行流程：
        状态机每帧执行检测当前状态条件==》状态遍历所有条件对象
        ==》达到条件==》执行对应状态         
         */
    }
}