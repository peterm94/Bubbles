using Bubbles.AI.Actions;
using Nez;
using Nez.AI.GOAP;

namespace Bubbles.AI.Agents
{
    public class EnemyAgent : Agent
    {
        private const string TARGET_ALIVE = "targetAlive";
        
        public EnemyAgent(Entity entity) 
        {
            // Not sure how dynamic targeting is going to work.
            var player = entity.scene.findEntity("Player");
            var attack = new AttackAction(player);
            attack.setPrecondition(TARGET_ALIVE, true);
            attack.setPostcondition(TARGET_ALIVE, false);
            _planner.addAction(attack);
        }

        public override WorldState getWorldState()
        {
            var newState = _planner.createWorldState();
            newState.set(TARGET_ALIVE, true);
            return newState;
        }

        public override WorldState getGoalState()
        {
            var newState = _planner.createWorldState();
            newState.set(TARGET_ALIVE, false);
            return newState;
        }
    }
}