using System;
using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    public class HeadTowardsEntitySystem : EntityProcessingSystem
    {
        private readonly Entity to;

        public HeadTowardsEntitySystem(Matcher matcher, Entity to) : base(matcher.all(typeof(Heading)))
        {
            this.to = to;
        }

        public override void process(Entity entity)
        {
            var dir = Math.Atan2(to.position.Y - entity.position.Y,
                                 to.position.X - entity.position.X);

            entity.getComponent<Heading>().Value = (float) dir;
        }
    }
}