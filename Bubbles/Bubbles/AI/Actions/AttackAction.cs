using System;
using Bubbles.AI.Boilerplate;
using Bubbles.Components;
using Bubbles.Components.Combat;
using Nez;

namespace Bubbles.AI.Actions
{
    public class AttackAction : EntityAction
    {
        public override bool RequiresInRange { get; } = true;
        protected override int Range { get; } = 50;

        public override bool Run(Entity entity)
        {
            var weapon = entity.getComponent<Equipped>().Equip;
            var input = weapon.getComponent<MeleeInput>();
            input.Swing = true;
            Console.WriteLine(Time.time + " Attack!");
            return true;
        }
        
        public AttackAction(Entity target, int cost = 1) : base("Attack", target, cost)
        {
        }
    }
}