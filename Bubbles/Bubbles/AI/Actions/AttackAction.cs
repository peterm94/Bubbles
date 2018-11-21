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
        
        public override bool Run()
        {
            var weapon = Entity.getComponent<Equipped>().Equip;
            var input = weapon.getComponent<MeleeInput>();
            input.Swing = true;
            return true;
        }

        public override void End()
        {
            var weapon = Entity.getComponent<Equipped>().Equip;
            weapon.getComponent<MeleeInput>().Clear();
        }

        public AttackAction(Entity entity, Entity target = null, int cost = 1) : base("Attack", entity, target, cost)
        {
        }
    }
}