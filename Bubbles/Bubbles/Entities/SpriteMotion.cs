using System;
using Bubbles.Components;
using Nez;

namespace Bubbles.Entities
{
    public class SpriteMotion<TEnum> : SpriteAction<TEnum, MotionInfo> where TEnum : struct, IComparable, IFormattable
    {
        private TransformLock _transformLock;

        protected override void Apply(MotionInfo action)
        {
            _transformLock.Locked = true;
            sprite.entity.setLocalPosition(action.Offset);
            sprite.entity.setLocalRotation(action.Angle);
        }

        protected override void Clear()
        {
            _transformLock.Locked = false;
        }

        public override void onAddedToEntity()
        {
            base.onEnabled();
            _transformLock = entity.getOrCreateComponent<TransformLock>();
        }
    }
}
