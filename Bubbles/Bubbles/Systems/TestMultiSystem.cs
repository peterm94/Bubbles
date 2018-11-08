using System;
using System.Collections.Generic;
using Nez;

namespace Bubbles.Systems
{
    public class TestMultiSystem : MultiEntityProcessingSystem
    {
        public TestMultiSystem(Scene scene, Matcher matcher, Dictionary<string, Matcher> others)
            : base(scene, matcher, others)
        {
        }

        protected override void process(Entity entity, Dictionary<string, MatchedSystem> others)
        {
            Console.WriteLine("I am " + entity.name);
            Console.WriteLine("I can see: " + others["enemies"].getEntities().Count + " enemies.");
        }
    }
}
