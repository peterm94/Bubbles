using System;
using Bubbles.Components;
using Bubbles.Entities;
using Bubbles.Util;
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
            Idle
        }

        public AnimateHammerSystem() : base(new Matcher().all(typeof(MeleeInput), 
                                                              typeof(Sprite<Animations>),
                                                              typeof(TransformLock),
                                                              typeof(SpriteCollider<Animations>)))
        {
        }

        public override void process(Entity entity)
        {
            var input = entity.getComponent<MeleeInput>();
            var sprite = entity.getComponent<Sprite<Animations>>();
            var transformLock = entity.getComponent<TransformLock>();
            var spriteCollider = entity.getComponent<SpriteCollider<Animations>>();
            
            
            var parent = entity.parent.entity;
            // Better hope the thing swinging can move :)
            var motion = parent.getComponent<Motion>();
            
            if (input.Swing)
            {
                if (!sprite.isPlaying || sprite.isAnimationPlaying(Animations.Idle))
                {
                    sprite.play(Animations.WarmUp);
                    entity.setRotation(Inaccuracy.MakeInaccurate(entity.rotation));
                    transformLock.Locked = true;
                    motion.SpeedMultiplier = 0.5f;
                }
            }
                        
            // Last frame of animation.
            if (sprite.currentFrame == sprite.getAnimation(sprite.currentAnimation).frames.Count - 1)
            {
                if (sprite.isAnimationPlaying(Animations.WarmUp))
                {
                    motion.SpeedMultiplier = 0.8f;
                    sprite.play(Animations.Swing);
                }
                else if (sprite.isAnimationPlaying(Animations.Swing))
                {
                    if (input.Swing)
                    {
                        motion.SpeedMultiplier = 0.5f;
                        spriteCollider.ClearHits();
                        sprite.play(Animations.Swing);   
                    }
                    else
                    {
                        motion.SpeedMultiplier = 1f;
                        sprite.play(Animations.CoolDown);
                    }
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