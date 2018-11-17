using System;
using Bubbles.Entities;
using Nez;

namespace Bubbles.Components
{
    public class SpriteMotion<TEnum> : FrameTriggerComponent<TEnum, MotionInfo>
        where TEnum : struct, IComparable, IFormattable
    {
        private TransformLock _transformLock;

        protected override void FrameEndTrigger(MotionInfo motion)
        {
            _transformLock.Locked = false;
        }

        protected override void FrameStartTrigger(MotionInfo motion)
        {
            _transformLock.Locked = true;
            entity.setLocalPosition(motion.Offset);
            entity.setLocalRotation(motion.Angle);
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            _transformLock = entity.getOrCreateComponent<TransformLock>();
        }
    }
}
