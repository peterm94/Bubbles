using System;
using System.Collections.Generic;
using Bubbles.Components;
using Nez;

namespace Bubbles.Systems.Combat
{
    public class DestroyEntitySystem : EntityProcessingSystem
    {
        public DestroyEntitySystem() : base(new Matcher().all(typeof(Destroyed)).exclude(typeof(WontDestroy)))
        {
        }

        public override void process(Entity entity)
        {
        }

        // We want to destroy last so that we don't break things.
        public override void lateProcess(Entity entity)
        {
            entity.destroy();
        }
    }
}