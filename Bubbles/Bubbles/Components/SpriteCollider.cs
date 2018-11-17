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
        private readonly Dictionary<Entity, Attacked> _hits = new Dictionary<Entity, Attacked>();

        protected override void FrameStartTrigger(Collider collider)
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

        protected override void AnimationEndTrigger(Collider collider)
        {
            Console.WriteLine("CLEARING");

            // Remove each hit component from the enemies
            // TODO i don't think we even need to do this any more?? the other entity can clear it when it's processed?
            foreach (var attack in _hits.Values)
            {
                attack.removeComponent();
            }

            _hits.Clear();
        }

        protected override void OnActionAdded(Collider collider)
        {
            // Add the collider to the entity.
            entity.addComponent(collider);
        }

        private void OnCollisionEnter(Collider other, Collider local)
        {
            // We don't want to hit the same guy twice in one animation.
            if (_hits.ContainsKey(other.entity)) return;

            Console.WriteLine("HIT " + other.entity.name);

            var attacked = other.entity.addComponent(new Attacked(local));
            _hits[local.entity] = attacked;
        }
    }
}
