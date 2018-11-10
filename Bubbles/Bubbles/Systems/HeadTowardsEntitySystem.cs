using System;
using Nez;

namespace Bubbles.Systems
{
    public class HeadTowardsEntitySystem : EntityProcessingSystem
    {
        private readonly Entity to;

        public HeadTowardsEntitySystem(Matcher matcher, Entity to) : base(matcher)
        {
            this.to = to;
        }

        public override void process(Entity entity)
        {
            var dir = Math.Atan2(to.position.Y - entity.position.Y,
                                 to.position.X - entity.position.X);

            entity.setRotation((float) dir);
        }
    }
}
