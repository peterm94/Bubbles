using System;
using Bubbles.Components;
using Bubbles.Util;
using Nez;

namespace Bubbles.Systems
{
    public class TestMultiSystem : MultiEntityProcessingSystem
    {
        private readonly MatchedSystem enemies;

        public TestMultiSystem(Scene scene) : base(scene, new Matcher().all(typeof(Player)))
        {
            enemies = InjectEntityMatcher(new Matcher().all(typeof(Enemy)));
        }

        public override void process(Entity entity)
        {
//            Console.WriteLine("I am " + entity.name);
//            Console.WriteLine("I can see: " + enemies.Entities().Count + " enemies.");
        }
    }
}
