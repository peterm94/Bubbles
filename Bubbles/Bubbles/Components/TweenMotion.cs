using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;

namespace Bubbles.Components
{
    public class TweenMotion : Component
    {
        public ITween<Vector2> Tween { get; set; }

        private readonly float _delayTimeSecs;
        private float _currentDelay;

        public TweenMotion(float delay = 0f)
        {
            Tween = null;
            _delayTimeSecs = delay;
        }

        public bool delayExpired()
        {
            _currentDelay += Time.deltaTime;
            if (_currentDelay  > _delayTimeSecs)
            {
                _currentDelay = 0f;
                return true;
            }

            return false;
        }
    }
}