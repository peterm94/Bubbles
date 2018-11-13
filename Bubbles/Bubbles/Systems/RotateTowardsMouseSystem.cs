using System;
using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems
{
    public class RotateTowardsMouseSystem : EntityProcessingSystem
    {
        public RotateTowardsMouseSystem() : base(new Matcher().all(typeof(RotateTowardsMouse)))
        {
        }

        public override void process(Entity entity)
        {
            var mousePos = Input.mousePosition;

            var dir = Math.Atan2(mousePos.Y - entity.position.Y,
                                 mousePos.X - entity.position.X);

            var animLocked = entity.getComponent<TransformLock>();

            if (animLocked == null || !animLocked.Locked)
            {
                entity.setLocalRotation((float) dir);
                entity.localRotationDegrees -= 90f;
            }
        }
    }
}
