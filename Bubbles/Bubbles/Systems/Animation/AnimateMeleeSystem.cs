using Bubbles.Components;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems
{
    public class AnimateMeleeSystem : EntityProcessingSystem
    {
        public enum Animations
        {
            Swing,
            Idle
        }

        public AnimateMeleeSystem() : base(new Matcher().all(typeof(MeleeInput), typeof(Sprite<Animations>)))
        {
        }

        public override void process(Entity entity)
        {
            var input = entity.getComponent<MeleeInput>();
            var sprite = entity.getComponent<Sprite<Animations>>();

            if (input.Swing)
            {
                if (!sprite.isAnimationPlaying(Animations.Swing))
                {
                    sprite.play(Animations.Swing);
                    sprite.entity.setRotationDegrees(-270);
                }                    
            }
            else
            {
                if (!sprite.isAnimationPlaying(Animations.Idle))
                {
                    sprite.play(Animations.Idle);
                    sprite.entity.setRotation(0);
                }
            }
        }
    }
}