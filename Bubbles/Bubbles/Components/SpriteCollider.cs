using System;
using System.Collections.Generic;
using Nez;

namespace Bubbles.Components
{
    public class SpriteCollider<TEnum> : FrameTriggerComponent<TEnum, Collider>
        where TEnum : struct, IComparable, IFormattable
    {
        private readonly Dictionary<Entity, Attacked> _hits = new Dictionary<Entity, Attacked>();

        /// <summary>
        /// Reset hit counter - allows for multiple hits in the same animation.
        /// </summary>
        public void ClearHits()
        {
            _hits.Clear();
        }
        
        protected override void FrameStartTrigger(Collider collider)
        {
            collider.enabled = true;

            // Do a broad collision check.
            var boxCast = Physics.boxcastBroadphaseExcludingSelf(collider, 0, 0, collider.collidesWithLayers);

            // For anything close, check for collisions.
            foreach (var other in boxCast)
            {
                if (collider.overlaps(other))
                {
                    OnCollisionEnter(other, collider);
                }
            }
        }

        protected override void FrameEndTrigger(Collider collider)
        {
            collider.enabled = false;
        }

        protected override void AnimationEndTrigger(TEnum prevAnim)
        {
            Console.WriteLine("CLEARING");
            _hits.Clear();
        }

        protected override void OnActionAdded(Collider collider)
        {
            // Add the collider to the entity.
            entity.addComponent(collider);
            collider.enabled = false;
        }

        private void OnCollisionEnter(Collider other, Collider local)
        {
            // We don't want to hit the same guy twice in one animation.
            if (_hits.ContainsKey(other.entity)) return;

            Console.WriteLine("HIT " + other.entity.name);

            var attacked = other.entity.addComponent(new Attacked(local));
            _hits[other.entity] = attacked;
        }
    }
}
