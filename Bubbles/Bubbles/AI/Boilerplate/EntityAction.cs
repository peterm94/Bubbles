using Nez;
using Nez.AI.GOAP;

namespace Bubbles.AI.Boilerplate
{
    /// <summary>
    /// GOAP Action that runs in the context of an Entity.
    /// </summary>
    public abstract class EntityAction : Action
    {
        // The Entity that the action is performing on.
        public readonly Entity Entity;
        
        // Target of the action (if there is one).
        public readonly Entity Target;

        // Returns whether the entity is in range of the action's target.
        public bool InRange(Entity entity)
        {
            return Movement.InRange(entity, Target, Range);
        }
        
        // Will be used for actions that take more than a frame.
        public bool IsDone { get; set; } = false;
        
        // Does the action require range at all?
        public abstract bool RequiresInRange { get; }
        
        // At what range is the entity considered "in range" of the target?
        protected abstract int Range { get;  }
        
        protected EntityAction(string name, Entity entity, Entity target = null, int cost = 1) : base(name, cost)
        {
            Entity = entity;
            Target = target;
        }
        
        // Run the action.
        public abstract bool Run();

        // Any clean up required on the frame after the action is run.
        public abstract void End();
    }
}