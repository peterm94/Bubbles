using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Nez;
using Nez.IEnumerableExtensions;

namespace Bubbles.Components
{
    public class SpriteCollider<TEnum> : FrameTriggerComponent<TEnum, Collider>
        where TEnum : struct, IComparable, IFormattable
    {
        private readonly Dictionary<Collider, List<Attacked>> _attacks = new Dictionary<Collider, List<Attacked>>();

        protected override void ExecuteTrigger(Collider collider)
        {
            // Do a broad collision check.
            var boxCast = Physics.boxcastBroadphaseExcludingSelf(collider, 0, 0, collider.collidesWithLayers);

            // For anything close, check for collisions.
            foreach (var other in boxCast)
            {
                if (collider.collidesWith(other, out var result))
                {
                    OnCollisionEnter(other, collider);
                }
            }
        }

        protected override void EndTrigger(Collider collider)
        {
            if (_attacks.ContainsKey(collider))
            {
                Console.WriteLine("CLEARING");

                _attacks[collider].ForEach(x => x.removeComponent());
                _attacks.Remove(collider);
            }
        }

        protected override void OnActionAdded(Collider collider)
        {
            // Add the collider to the entity.
            entity.addComponent(collider);
        }

        private void OnCollisionEnter(Collider other, Collider local)
        {
            Console.WriteLine("HIT " + other.entity.name);

            var attacked = other.entity.addComponent(new Attacked(local));

            if (_attacks.ContainsKey(local))
            {
                _attacks[local].Add(attacked);
            }
            else
            {
                _attacks[local] = new List<Attacked> {attacked};
            }
        }
    }
}
