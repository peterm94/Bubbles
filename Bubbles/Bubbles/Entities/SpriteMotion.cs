using System;
using System.Collections.Generic;
using Bubbles.Components;
using Nez;
using Nez.Sprites;

namespace Bubbles.Entities
{
    public class SpriteMotion<TEnum> : Component, IUpdatable where TEnum : struct, IComparable, IFormattable
    {
        private readonly Dictionary<TEnum, Dictionary<int, MotionInfo>> _motionStates;
        private Dictionary<int, MotionInfo> _currMotion;
        private int _prevFrame;

        private TEnum _prevState;
        private Sprite<TEnum> _sprite;
        private TransformLock _transformLock;

        public SpriteMotion()
        {
            _motionStates = new Dictionary<TEnum, Dictionary<int, MotionInfo>>();
        }

        public SpriteMotion(Dictionary<TEnum, Dictionary<int, MotionInfo>> motionStates)
        {
            _motionStates = motionStates;
        }


        public void update()
        {
            var currState = _sprite.currentAnimation;
            var currFrame = _sprite.currentFrame;
            if (!_prevState.Equals(currState))
            {
                // State change
                var motionExists = _motionStates.TryGetValue(currState, out _currMotion);
                if (motionExists)
                {
                    var stateExists = _currMotion.TryGetValue(currFrame, out var motion);
                    if (stateExists)
                    {
                        ApplyMotion(motion);
                    }
                    else
                    {
                        ClearMotion();
                    }
                }
                else
                {
                    ClearMotion();
                }
            }
            else if (!_prevFrame.Equals(currFrame))
            {
                // Frame change
                if (_currMotion != null)
                {
                    var stateExists = _currMotion.TryGetValue(currFrame, out var motion);
                    if (stateExists)
                    {
                        ApplyMotion(motion);
                    }
                    else
                    {
                        ClearMotion();
                    }
                }
                else
                {
                    ClearMotion();
                }
            }

            _prevState = currState;
            _prevFrame = currFrame;
        }

        public override void onEnabled()
        {
            base.onEnabled();
            _sprite = entity.getComponent<Sprite<TEnum>>();
            _transformLock = entity.getComponent<TransformLock>();
        }

        public SpriteMotion<TEnum> addMotionInfo(TEnum key, int frame, MotionInfo motionInfo)
        {
            if (_motionStates.ContainsKey(key))
            {
                _motionStates[key][frame] = motionInfo;
            }
            else
            {
                _motionStates[key] = new Dictionary<int, MotionInfo> {[frame] = motionInfo};
            }

            return this;
        }

        private void ApplyMotion(MotionInfo motion)
        {
            _transformLock.Locked = true;
            _sprite.entity.setLocalPosition(motion.Offset);
            _sprite.entity.setLocalRotation(motion.Angle);
        }

        private void ClearMotion()
        {
            _transformLock.Locked = false;
        }
    }
}
