using Nez;
using Nez.AI.GOAP;

namespace Bubbles.AI
{
    public abstract class RunnableAction : Action
    {
        protected RunnableAction()
        {
        }

        protected RunnableAction(string name) : base(name)
        {
        }

        protected RunnableAction(string name, int cost) : base(name, cost)
        {
        }

        public abstract void Run(Entity entity);
    }
}