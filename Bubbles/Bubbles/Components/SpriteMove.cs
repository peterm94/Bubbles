using System;
using Bubbles.Entities;
using Nez;

namespace Bubbles.Components
{
    public class SpriteMove<TEnum> : FrameTriggerComponent<TEnum, MotionInfo>
        where TEnum : struct, IComparable, IFormattable
    {
        private TransformLock _transformLock;

        protected override void ClearPrevious()
        {
            _transformLock.Locked = false;
        }

        protected override void ExecuteTrigger(MotionInfo action)
        {
            _transformLock.Locked = true;
            entity.setLocalPosition(action.Offset);
            entity.setLocalRotation(action.Angle);
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            _transformLock = entity.getOrCreateComponent<TransformLock>();
        }
    }
}
