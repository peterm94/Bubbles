using Bubbles.Components;
using Bubbles.Components.Combat;
using Nez;

namespace Bubbles.Systems.Combat
{
    public class BringOutYourDead : EntityProcessingSystem
    {
        public BringOutYourDead() : base(new Matcher().all(typeof(Health)))
        {
        }

        public override void process(Entity entity)
        {
            if (entity.getComponent<Health>().Hp <= 0)
            {
                entity.addComponent<Destroyed>();
            }
        }
    }
}