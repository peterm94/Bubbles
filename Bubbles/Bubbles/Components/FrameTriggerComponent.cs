using System;
using System.Collections.Generic;
using Nez;
using Nez.Sprites;

namespace Bubbles.Components
{
    public abstract class FrameTriggerComponent<TEnum, ActionType> : Component, IUpdatable
        where TEnum : struct, IComparable, IFormattable
    {
        private readonly Dictionary<TEnum, Dictionary<int, ActionType>> _actionStates;

        private TEnum _prevAnim;
        private int _prevFrame;
        private ActionType _prevFrameAction;
        private ActionType _prevAnimAction;

        private Sprite<TEnum> _triggerSprite;

        protected FrameTriggerComponent()
        {
            _actionStates = new Dictionary<TEnum, Dictionary<int, ActionType>>();
        }

        public void update()
        {
            if (!_triggerSprite.currentAnimation.Equals(_prevAnim))
            {
                // Animation change.
                // Call the end of animation trigger.
                if (_prevAnimAction != null)
                {
                    AnimationEndTrigger(_prevAnimAction);
                }

                if (_prevFrameAction != null)
                {
                    FrameEndTrigger(_prevFrameAction);
                }

                _prevAnimAction = default(ActionType);
                _prevFrameAction = default(ActionType);

                // Get the required frame and execute the action.
                TryTrigger(_triggerSprite.currentAnimation, _triggerSprite.currentFrame, true);
            }
            else if (!_prevFrame.Equals(_triggerSprite.currentFrame))
            {
                // Frame change. Call the frame end trigger for the previous frame.
                if (_prevFrameAction != null)
                    FrameEndTrigger(_prevFrameAction);

                _prevFrameAction = default(ActionType);

                // Get the next frame and execute.
                TryTrigger(_triggerSprite.currentAnimation, _triggerSprite.currentFrame, false);
            }

            _prevAnim = _triggerSprite.currentAnimation;
            _prevFrame = _triggerSprite.currentFrame;
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            _triggerSprite = entity.getComponent<Sprite<TEnum>>();
        }

        private void TryTrigger(TEnum anim, int frame, bool animStart)
        {
            if (_actionStates.ContainsKey(anim))
            {
                var animActions = _actionStates[anim];

                if (animActions.ContainsKey(frame))
                {
                    var action = animActions[frame];

                    // If it is the start of the animation as well as the start of the frame, trigger this method too.
                    if (animStart)
                        AnimationStartTrigger(action);

                    FrameStartTrigger(action);
                    _prevAnimAction = action;
                    _prevFrameAction = action;
                    return;
                }
            }
        }

        public FrameTriggerComponent<TEnum, ActionType> AddAction(TEnum key, int frame, ActionType action)
        {
            if (_actionStates.ContainsKey(key))
            {
                _actionStates[key][frame] = action;
            }
            else
            {
                _actionStates[key] = new Dictionary<int, ActionType> {[frame] = action};
            }

            OnActionAdded(action);
            return this;
        }

        protected virtual void FrameStartTrigger(ActionType action)
        {
        }

        protected virtual void OnActionAdded(ActionType action)
        {
        }

        protected virtual void AnimationStartTrigger(ActionType action)
        {
        }

        protected virtual void AnimationEndTrigger(ActionType action)
        {
        }

        protected virtual void FrameEndTrigger(ActionType action)
        {
        }
    }
}
