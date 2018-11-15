using System;
using System.Collections.Generic;
using Bubbles.Components;
using Nez;
using Nez.Sprites;

namespace Bubbles.Entities
{
    public abstract class SpriteAction<TEnum, ActionType> : Component, IUpdatable
        where TEnum : struct, IComparable, IFormattable
    {
        protected abstract void Apply(ActionType action);
        protected abstract void Clear();

        protected Sprite<TEnum> sprite;

        private readonly Dictionary<TEnum, Dictionary<int, ActionType>> _actionStates;
        private Dictionary<int, ActionType> _currState;
        private int _prevFrame;

        private TEnum _prevState;
        private TransformLock _transformLock;

        public SpriteAction()
        {
            _actionStates = new Dictionary<TEnum, Dictionary<int, ActionType>>();
        }

        public SpriteAction(Dictionary<TEnum, Dictionary<int, ActionType>> actionStates)
        {
            _actionStates = actionStates;
        }


        public void update()
        {
            var currState = sprite.currentAnimation;
            var currFrame = sprite.currentFrame;

            if (!_prevState.Equals(currState))
            {
                // State change
                var stateExists = _actionStates.TryGetValue(currState, out _currState);
                if (stateExists)
                {
                    var frameExists = _currState.TryGetValue(currFrame, out var action);
                    if (frameExists)
                    {
                        Apply(action);
                    }
                    else
                    {
                        Clear();
                    }
                }
                else
                {
                    Clear();
                }
            }
            else if (!_prevFrame.Equals(currFrame))
            {
                // Frame change
                if (_currState != null)
                {
                    var stateExists = _currState.TryGetValue(currFrame, out var action);
                    if (stateExists)
                    {
                        Apply(action);
                    }
                    else
                    {
                        Clear();
                    }
                }
                else
                {
                    Clear();
                }
            }

            _prevState = currState;
            _prevFrame = currFrame;
        }

        public override void onEnabled()
        {
            base.onEnabled();
            sprite = entity.getComponent<Sprite<TEnum>>();
            _transformLock = entity.getComponent<TransformLock>();
        }

        public SpriteAction<TEnum, ActionType> AddAction(TEnum key, int frame, ActionType action)
        {
            if (_actionStates.ContainsKey(key))
            {
                _actionStates[key][frame] = action;
            }
            else
            {
                _actionStates[key] = new Dictionary<int, ActionType> {[frame] = action};
            }

            return this;
        }
    }
}
