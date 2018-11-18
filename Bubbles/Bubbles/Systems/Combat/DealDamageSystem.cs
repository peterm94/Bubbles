using Bubbles.Components;
using Bubbles.Components.Combat;
using Nez;

namespace Bubbles.Systems.Combat
{
    public class DealDamageSystem : EntityProcessingSystem
    {
        public DealDamageSystem() : base(new Matcher().all(typeof(Health), typeof(Attacked)))
        {
        }

        public override void process(Entity entity)
        {
            entity.getComponent<Health>().Hp -= entity.getComponent<Attacked>().Damage;
            entity.removeComponent<Attacked>();
        }
    }
}