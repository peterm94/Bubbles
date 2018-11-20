using System;
using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    public class RotateTowardsEntitySystem : EntityProcessingSystem
    {
        public RotateTowardsEntitySystem() : base(new Matcher().all(typeof(RotateTowards)))
        {
        }

        public override void process(Entity entity)
        {
            var to = entity.getComponent<RotateTowards>().Towards;

            if (to == null) return;
            
            var dir = Math.Atan2(to.position.Y - entity.position.Y,
                                 to.position.X - entity.position.X);

            var animLocked = entity.getComponent<TransformLock>();

            if (animLocked == null || !animLocked.Locked)
            {
                entity.setLocalRotation((float) dir);
                entity.localRotationDegrees -= 90f;
            }
        }
    }
}