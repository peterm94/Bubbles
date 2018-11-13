using Bubbles.Components;
using Nez;

namespace Bubbles.Systems.Position
{
    public class TrackMouseSystem : EntityProcessingSystem
    {
        public TrackMouseSystem() : base(new Matcher().all(typeof(Cursor)))
        {
        }

        public override void process(Entity entity)
        {
            entity.setPosition(Input.scaledMousePosition);
        }
    }
}