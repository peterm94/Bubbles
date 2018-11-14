using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;

namespace Bubbles.Systems
{
    public class ChargeEntitySystem : EntityProcessingSystem
    {
        private const int Delay = 1;

        private readonly Entity _target;
        private Vector2 _destination;
        private Vector2 _direction;
        private ITween<Vector2> _tween;
        private double _waitTime;

        public ChargeEntitySystem(Matcher matcher, Entity target) : base(matcher)
        {
            _target = target;
        }

        public override void process(Entity entity)
        {
            if (_tween != null && !_tween.isRunning())
            {
                // Finished moving.
                // Wait before moving again.
                _waitTime += Time.deltaTime;
                if (_waitTime < Delay)
                {
                    return;
                }

                // Have waited long enough.
                _waitTime = 0;
            }

            if (_tween == null || !_tween.isRunning())
            {
                StartTween(entity);
            }
        }

        private void StartTween(Entity entity)
        {
            // If not moving, figure out the next place to move.
            _destination = _target.position;
            _direction = Vector2.Normalize(_destination - entity.position);
            // Add a bit to the destination - want to go past the player.
            _destination += _direction * 30;

            _tween = entity.tweenPositionTo(_destination);
            // TODO make duration a function of distance - try keep the speed the same.
            _tween.setDuration(1.0f);
            _tween.start();
        }
    }
}
