using System;
using Nez;

namespace Bubbles.Components
{
    public class SpriteCollider<TEnum> : FrameTriggerComponent<TEnum, Collider>
        where TEnum : struct, IComparable, IFormattable
    {
        protected override void ExecuteTrigger(Collider collider)
        {
            // Enable the collider
            collider.enabled = true;
        }

        protected override void EndTrigger(Collider collider)
        {
            collider.enabled = false;
        }

        protected override void OnActionAdded(Collider collider)
        {
            // Add the collider to the entity but disable it.
            entity.addComponent(collider).setEnabled(false);
        }
    }
}
