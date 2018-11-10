using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    public class EntityMousePositionSystem : EntityProcessingSystem
    {
        public EntityMousePositionSystem() : base(new Matcher().all(typeof(Cursor)))
        {
        }

        public override void process(Entity entity)
        {
            entity.setPosition(Input.scaledMousePosition);
        }
    }
}