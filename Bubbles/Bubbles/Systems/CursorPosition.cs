using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    public class CursorPosition : EntityProcessingSystem
    {
        public CursorPosition() : base(new Matcher().all(typeof(Cursor)))
        {
        }

        public override void process(Entity entity)
        {
            entity.setPosition(Input.scaledMousePosition);
        }
    }
}