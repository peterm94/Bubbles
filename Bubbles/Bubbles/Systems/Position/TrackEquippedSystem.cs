using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Systems.Position
{
    public class TrackEquippedSystem : EntityProcessingSystem
    {
        public TrackEquippedSystem() : base(new Matcher().all(typeof(Equipped)))
        {
            
        }

        public override void process(Entity entity)
        {
            var tracked = entity.getComponent<Equipped>();

            entity.setPosition(tracked.Wielder.position + tracked.Offset);
        }
    }
}