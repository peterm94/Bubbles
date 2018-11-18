using Bubbles.Components;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems.Animation
{
    public class AnimateComboSystem : EntityProcessingSystem
    {
        public enum Animations
        {
            WarmUp,
            Swing,
            CoolDown,
            NextSwing,
            Idle
        }

        public AnimateComboSystem() : base(new Matcher().all(typeof(MeleeInput), typeof(Sprite<Animations>),
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
                if (!sprite.isAnimationPlaying(Animations.Swing))
                {
                    sprite.play(Animations.Swing);
                    sprite.onAnimationCompletedEvent += animations =>
                    {
                        sprite.play(Animations.Idle);
                        transformLock.Locked = false;
                    };
                    transformLock.Locked = true;
                }
                // Last frame of swing.
                else if (sprite.currentFrame == sprite.getAnimation(Animations.Swing).frames.Count)
                {
                    
                }
            }

            if (!sprite.isPlaying)
            {
                sprite.play(Animations.Idle);
            }
        }
    }
}