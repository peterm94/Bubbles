using System;
using Bubbles.Components;
using Nez;
using Nez.AI.FSM;
using Nez.AI.GOAP;
// ReSharper disable UnusedMember.Local
// ReSharper disable ArrangeTypeMemberModifiers

namespace Bubbles.AI.Boilerplate
{
    public class GOAPStateMachine : SimpleStateMachine<GOAPStateMachine.State>
    {
        private EntityAction previousAction = null;
        
        public enum State
        {
            Idle,
            Goto,
            Animate
        }

        private readonly Agent agent;
        
        public GOAPStateMachine(Agent agent)
        {
            this.agent = agent;
        }

        public override void onAddedToEntity()
        {
            initialState = State.Idle;
        }

        private EntityAction Peek()
        {
            return agent.actions.Peek() as EntityAction;
        }

        private EntityAction Pop()
        {
            return agent.actions.Pop() as EntityAction;
        }

        void Idle_Tick()
        {
            // We need a plan!
            agent.plan();

            if (agent.hasActionPlan())
            {
                currentState = State.Animate;
            }
        }

        void Goto_Enter()
        {
            var action = Peek();

            if (action.RequiresInRange && action.Target == null)
            {
                Console.WriteLine("ERROR: Action requires range but does not have a target. Aborting.");
                currentState = State.Idle;
            }
        }

        void Goto_Tick()
        {
            var action = Peek();

            if (action.InRange(entity))
            {
                currentState = State.Animate;
            }
            else
            {
                Movement.Move(entity, action.Target);
            }
        }

        void Goto_Exit()
        {
            Movement.Clear(entity);
        }

        void Animate_Tick()
        {                        
            // Need to run cleanup for the previous frame.
            if (currentState == previousState)
            {
                previousAction?.End();   
            }
            
            // Out of actions, we need a new plan!
            if (!agent.hasActionPlan())
            {
                currentState = State.Idle;
                return;
            }

            var action = Peek();
            
            // If the action is complete, go to the next one.
            if (action.IsDone) Pop();
            
            // If we are out of range, move before the action can be performed.
            if (action.RequiresInRange && !action.InRange(entity))
            {
                currentState = State.Goto;
                return;
            }

            // We can finally run the action now :)
            var success = action.Run();
            previousAction = action;
            Pop();
            
            // Hardcore failure state that aborts the entire plan.
            if (!success)
            {
                currentState = State.Idle;
            }
        }

        void Animate_Exit()
        {
            previousAction?.End();
        }
    }
}