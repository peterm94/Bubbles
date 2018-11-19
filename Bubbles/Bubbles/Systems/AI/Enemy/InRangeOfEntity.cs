using Bubbles.AI;
using Bubbles.Components.AI;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Systems.AI.Enemy
{
    public class InRangeOfEntity : EntityProcessingSystem
    {
        private readonly Entity to;

        public InRangeOfEntity(Entity to) : base(new Matcher().all(typeof(InRange)))
        {
            this.to = to;
        }

        public override void process(Entity entity)
        {
            var inRange = Vector2.Distance(entity.position, to.position) < 50;
            entity.getComponent<InRange>().Value = inRange;
        }
    }
}