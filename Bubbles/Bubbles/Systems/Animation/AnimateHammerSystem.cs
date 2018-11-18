using System;
using Bubbles.Components;
using Bubbles.Entities;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems.Animation
{
    public class AnimateHammerSystem : EntityProcessingSystem
    {
        public enum Animations
        {
            WarmUp,
            Swing,
            CoolDown,
            NextSwing,
            Idle
        }

        public AnimateHammerSystem() : base(new Matcher().all(typeof(MeleeInput), typeof(Sprite<Animations>),
                                                              typeof(TransformLock)))
        {
        }

        public override void process(Entity entity)
        {
            var input = entity.getComponent<MeleeInput>();
            var sprite = entity.getComponent<Sprite<Animations>>();
            var transformLock = entity.getComponent<TransformLock>();

            if (input.Swing)
            {
                if (!sprite.isPlaying || sprite.isAnimationPlaying(Animations.Idle))
                {
                    sprite.play(Animations.WarmUp);
                    transformLock.Locked = true;
                }
            }
            
            Console.WriteLine("Frame:" + sprite.currentFrame + ". Count: " + sprite.getAnimation(sprite.currentAnimation).frames.Count);
            
            // Last frame of animation.
            if (sprite.currentFrame == sprite.getAnimation(sprite.currentAnimation).frames.Count - 1)
            {
                if (sprite.isAnimationPlaying(Animations.WarmUp))
                {
                    sprite.play(Animations.Swing);
                }
                else if (sprite.isAnimationPlaying(Animations.Swing))
                {
                    sprite.play(input.Swing ? Animations.Swing : Animations.CoolDown);
                }
                else if (sprite.isAnimationPlaying(Animations.CoolDown))
                {
                    sprite.play(Animations.Idle);
                    transformLock.Locked = false;
                }
            }

            if (!sprite.isPlaying)
            {
                sprite.play(Animations.Idle);
            }
        }
    }
}