using Bubbles.Components;
using Nez;

namespace Bubbles.AI
{
    public class StopAction : RunnableAction
    {
        public override void Run(Entity entity)
        {
            entity.getComponent<MovementInput>().Clear();
        }
    }
}