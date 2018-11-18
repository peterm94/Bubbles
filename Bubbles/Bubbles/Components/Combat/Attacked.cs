using Nez;

namespace Bubbles.Components
{
    public class Attacked : Component
    {
        public Attacked(Collider hitter)
        {
            Hitter = hitter;
        }

        public short Damage { get; set; } = 50;
        public Collider Hitter { get; }

        public override void onAddedToEntity()
        {
            // TODO This means that all enemies flash white and the sleep is always the same.
            // This should instead be up to the entity being attacked.
            entity.addComponent(new FlashWhite());
            entity.addComponent(new Sleep {Timeout = 50});
        }
    }
}