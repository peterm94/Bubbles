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

            var dirVector = mousePos;

            entity.transform.setRotationDegrees(Vector2Ext.angle(dirVector, mousePos));
        }
    }
}
