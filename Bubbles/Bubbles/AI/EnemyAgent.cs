using System;
using System.Collections.Generic;
using Bubbles.Components.AI;
using Nez;
using Nez.AI.GOAP;
using Action = Nez.AI.GOAP.Action;

namespace Bubbles.AI
{
    public class EnemyAgent : Agent
    {
        private readonly InRange inRange; 
        private const string IN_RANGE = "inRange";
        
        public EnemyAgent(Entity entity)
        {
            inRange = entity.getComponent<InRange>();
            
            var move = new MoveAction();
            move.setPrecondition(IN_RANGE, false);
            move.setPostcondition(IN_RANGE, true);
            _planner.addAction(move);

            var attack = new Action("Attack");
            attack.setPrecondition(IN_RANGE, true);
            _planner.addAction(attack);
        }

        public override WorldState getWorldState()
        {
            var newState = _planner.createWorldState();
            newState.set(IN_RANGE, inRange.Value);
            return newState;
        }

        public override WorldState getGoalState()
        {
            var newState = _planner.createWorldState();
            newState.set(IN_RANGE, true);
            return newState;
        }
    }
}