using System.Collections.Generic;
using System.Threading.Tasks;
using Nez;

namespace Bubbles.Util
{
    public abstract class ParallelEntityProcessingSystem : EntitySystem
    {
        public ParallelEntityProcessingSystem(Matcher matcher) : base(matcher)
        {
        }

        public abstract void process(Entity entity);


        public virtual void lateProcess(Entity entity)
        {
        }

        protected override void process(List<Entity> entities)
        {
            Parallel.ForEach(entities, process);
        }


        protected override void lateProcess(List<Entity> entities)
        {
            Parallel.ForEach(entities, process);
        }
    }
}
