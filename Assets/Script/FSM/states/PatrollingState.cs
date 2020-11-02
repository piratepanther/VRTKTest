using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.FSM
{
    class PatrollingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Patrolling;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            fsm.IspatrolComplete = false;
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            switch (fsm.patrolMode)
            {
                case PatrolMode.Once:
                    OncePatrolling(fsm);
                    break;
                case PatrolMode.Loop:
                    LoopPatrolling(fsm);
                    break;
                case PatrolMode.PingPong:
                    PingPongPatrolling(fsm);
                    break;
            }

        }

        public int index;
        //根据巡逻模式ABC都是数据，应在机里面找
            //--往返 A=B=C=B=A.....
        private void PingPongPatrolling(FSMBase fsm)
        {
            throw new NotImplementedException();
        }

            //--循环 A=B=C=A.....
        private void LoopPatrolling(FSMBase fsm)
        {
            throw new NotImplementedException();
        }

            //--单次 A-B-C
        private void OncePatrolling(FSMBase fsm)
        {
            if (Vector3.Distance(fsm.transform.position, fsm.wayPoints[index].position) < 0.5f)
            {
                if (index == fsm.wayPoints.Length - 1)
                {

                    //完成巡逻
                    fsm.IspatrolComplete = true;
                    return;//退出
                }
                index++;
            }
                //fsm.wayPoints[2].position;
                fsm.MoveToTarget(fsm.wayPoints[index].position,0,fsm.walkSpeed);
        }
    }
}
