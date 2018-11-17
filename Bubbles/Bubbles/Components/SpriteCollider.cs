using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez;
using Nez.IEnumerableExtensions;

namespace Bubbles.Components
{
    public class SpriteCollider<TEnum> : FrameTriggerComponent<TEnum, Collider>
        where TEnum : struct, IComparable, IFormattable
    {
        private Dictionary<Collider, List<Attacked>> _attacks = new Dictionary<Collider, List<Attacked>>();

        protected override void ExecuteTrigger(Collider collider)
        {
            // Enable the collider
            if (collider.collidesWithAny(out var res))
            {
                onTriggerEnter(res.collider, collider);
            }
//            collider.enabled = true;
        }

        protected override void EndTrigger(Collider collider)
        {
//            collider.enabled = false;
            if (_attacks.ContainsKey(collider))
            {
                Console.WriteLine("CLEARING");

                _attacks[collider].ForEach(x => x.removeComponent());
                _attacks.Remove(collider);
            }
        }

        protected override void OnActionAdded(Collider collider)
        {
            // Add the collider to the entity but disable it.
            entity.addComponent(collider);
//            collider.setEnabled(false);
        }

        public void onTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine("HIT");

            var attk = other.entity.addComponent(new Attacked(local));

            if (_attacks.ContainsKey(local))
            {
                _attacks[local].Add(attk);
            }
            else
            {
                _attacks[local] = new List<Attacked> {attk};
            }
        }
    }
}
