using System;
using Bubbles.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Tweens;

namespace Bubbles.Systems
{
    public class ChargeEntitySystem : EntityProcessingSystem
    {
        private readonly Entity _target;

        public ChargeEntitySystem(Entity target) : base(new Matcher().all(typeof(Enemy), typeof(TweenMotion)))
        {
            _target = target;
        }

        public override void process(Entity entity)
        {
            var tweenMotion = entity.getComponent<TweenMotion>();

            if (tweenMotion.Tween == null || !tweenMotion.Tween.isRunning())
            {
                if (tweenMotion.delayExpired())
                {
                    entity.getComponent<TweenMotion>().Tween = StartTween(entity);
                }
            }
        }

        private ITween<Vector2> StartTween(Entity entity)
        {
            // If not moving, figure out the next place to move.
            var destination = _target.position;
            var direction = Vector2.Normalize(destination - entity.position);
            // Add a bit to the destination - want to go past the player.
            destination += direction * 30;

            var tween = entity.tweenPositionTo(destination);
            // TODO make duration a function of distance - try keep the speed the same.
            tween.setDuration(1.0f);
            tween.setRecycleTween(false);
            tween.start();
            return tween;
        }
    }
}
