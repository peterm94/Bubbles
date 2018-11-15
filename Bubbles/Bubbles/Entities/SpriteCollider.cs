using System;
using System.Collections.Generic;
using Nez;

namespace Bubbles.Entities
{
    public class SpriteCollider<TEnum> : Component, IUpdatable where TEnum : struct, IComparable, IFormattable
    {
        private readonly Dictionary<TEnum, Dictionary<int, Collider>> _colliders;

        public SpriteCollider()
        {
            _colliders = new Dictionary<TEnum, Dictionary<int, Collider>>();
        }

        public void update()
        {
        }
    }
}
