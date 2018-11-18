using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    public class SleepSystem : EntitySystem
    {
        public SleepSystem() : base(new Matcher().all(typeof(Sleep)))
        {
        }

        protected override void process(List<Entity> entities)
        {
            if (entities.Count == 0) return;

            var max = entities.Select(e => e.getComponent<Sleep>().Timeout).Max();
            Thread.Sleep(max);
            
            foreach (var entity in entities)
            {
                entity.removeComponent<Sleep>();
            }
        }
    }
}