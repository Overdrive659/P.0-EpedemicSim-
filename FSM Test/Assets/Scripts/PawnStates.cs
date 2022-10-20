using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class Idle : BaseState
    {
        InfectionController controller;
        public Idle(PawnSM stateMachine) : base("Idle", stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                stateMachine.ChangeState(((PawnSM)stateMachine).infectedState);
            }

            if (controller.hasInfection == true)
            {
                Debug.Log("Infected <-- Not Infected");
                stateMachine.ChangeState(((PawnSM)stateMachine).infectedState);
            }

        }
    }

    public class Infected : BaseState
    {
        private InfectionController controller;

        public Infected(PawnSM stateMachine) : base("Idle", stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            stateMachine.ChangeState(((PawnSM)stateMachine).idleState);
        }
    }
    }


