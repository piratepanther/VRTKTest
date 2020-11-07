using Common;
using System;
using UnityEngine;

namespace Assets.Script.FSM2
{
    /// <summary>
    /// 寻路状态
    /// </summary>
    class PathfindingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Patrolling;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsm.IsPathFindingComplete = false;
            fsm.anim.SetBool(fsm.enemyStates.chParams.run, true);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
//             switch (fsm.patrolMode)
//             {
//                 case PatrolMode.Once:
//                     OncePatrolling(fsm);
//                     break;
//                 case PatrolMode.Loop:
//                     LoopPatrolling(fsm);
//                     break;
//                 case PatrolMode.PingPong:
//                     PingPongPatrolling(fsm);
//                     break;
//             }
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
            {
                if (index == fsm.wayPoints.Length - 1)
                {

                    //完成巡逻
                    fsm.IsPathFindingComplete = true;
                    return;//退出
                }
                index++;
            }
            //fsm.wayPoints[2].position;
            // fsm.MoveToTarget(fsm.wayPoints[index].position,0,fsm.walkSpeed);
            fsm.transform.position = Vector3.MoveTowards(fsm.transform.position, fsm.wayPoints[index].position,Time.deltaTime*fsm.runSpeed);
            //fsm.transform.LookAt(fsm.wayPoints[index].position);
            fsm.transform.LookAtPosition(fsm.wayPoints[index].position, fsm.rotateSpeed);

        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.anim.SetBool(fsm.enemyStates.chParams.run, false);
        }

        public int index;
        //根据巡逻模式ABC都是数据，应在机里面找
        //--往返 A=B=C=B=A.....
//         private void PingPongPatrolling(FSMBase fsm)
//         {
//             if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
//             {
//                 if (index == fsm.wayPoints.Length - 1)
//                 {
//                     Array.Reverse(fsm.wayPoints);
//                     index++;
//                 }
//                 
//                 index = (index + 1) % fsm.wayPoints.Length;
// 
// 
//             }
//             fsm.MoveToTarget(fsm.wayPoints[index].position, 0, fsm.walkSpeed);
// 
// 
//         }
// 
//         //--循环 A=B=C=A.....
//         private void LoopPatrolling(FSMBase fsm)
//         {
//             if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
//             {                
// //                 if (index == fsm.wayPoints.Length - 1)
// //                 {
// // 
// //                     index--;
// //                 }
// //                 index ++;
//                 index = (index + 1) % fsm.wayPoints.Length;
// 
// 
//             }
//             fsm.MoveToTarget(fsm.wayPoints[index].position, 0, fsm.walkSpeed);
//         }

            //--单次 A-B-C
//         private void OncePatrolling(FSMBase fsm)
//         {
//             
//         }
    }
}
