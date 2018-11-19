using System;
using Bubbles.Components;
using Bubbles.Components.AI;
using Bubbles.Systems.Animation;
using Nez;
using Nez.AI.FSM;

// ReSharper disable ArrangeTypeMemberModifiers

namespace Bubbles.AI
{
    public class EnemyAI : SimpleStateMachine<EnemyAI.Action>
    {
        public enum Action
        {
            Idle,
            Goto,
            Animate
        }
        
        private EnemyAgent agent;
    
        public override void onAddedToEntity()
        {
            agent = new EnemyAgent(entity);
            initialState = Action.Idle;
        }

        #region states

        void Idle_Tick()
        {
            // We need a plan!
            agent.plan();

            if (agent.hasActionPlan())
            {
                var action = (RunnableAction) agent.actions.Peek();

                // Movement has special logic for... no reason?
                currentState = action is MoveAction ? Action.Goto : Action.Animate;   
            }
            else
            {
                // Uh oh!
            }
        }

        void Goto_Enter()
        {
            var action = (RunnableAction) agent.actions.Pop();
            action.Run(entity);
        }

        void Goto_Tick()
        {
            if (!agent.hasActionPlan())
            {
                currentState = Action.Idle;
            }
        }

        void Goto_Exit()
        {
            entity.getComponent<MovementInput>().Clear();
        }

        void Animate_Enter()
        {
            var action = (RunnableAction) agent.actions.Pop();
            action.Run(entity);
        }
    
        #endregion
    }
}