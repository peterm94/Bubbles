using Bubbles.Components;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems
{
    public class AnimatedEntitySystem : EntityProcessingSystem
    {
        public enum Animations
        {
            Walk,
            Idle
        }

        public AnimatedEntitySystem() : base(new Matcher().all(typeof(CharInput), typeof(Sprite<Animations>)))
        {
        }

        public override void process(Entity entity)
        {
            var input = entity.getComponent<CharInput>();
            var sprite = entity.getComponent<Sprite<Animations>>();

            if (input.AnyMove())
            {
                if (!sprite.isAnimationPlaying(Animations.Walk))
                    sprite.play(Animations.Walk);
            }
            else
            {
                if (!sprite.isAnimationPlaying(Animations.Idle))
                {
                    sprite.play(Animations.Idle);
                }
            }
        }
    }
}
