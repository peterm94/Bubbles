using System;
using System.Collections.Generic;
using Nez;

namespace Bubbles.Entities
{
    public class SpriteCollider<TEnum> : SpriteAction<TEnum, Collider> where TEnum : struct, IComparable, IFormattable
    {
        protected override void Apply(Collider collider)
        {
            // Enable the collider
            collider.enabled = true;
        }

        protected override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
