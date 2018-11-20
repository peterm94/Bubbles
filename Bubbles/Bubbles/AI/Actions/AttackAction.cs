using System;
using Bubbles.AI.Boilerplate;
using Nez;

namespace Bubbles.AI.Actions
{
    public class AttackAction : EntityAction
    {
        public override bool RequiresInRange { get; } = true;
        protected override int Range { get; } = 50;

        public override bool Run(Entity entity)
        {
            Console.WriteLine(Time.time + " Attack!");
            return true;
        }

        public AttackAction(Entity target, int cost = 1) : base("Attack", target, cost)
        {
        }
    }
}