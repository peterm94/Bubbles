using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Systems
{
    public class MovementSystem : EntityProcessingSystem
    {
        private const float speed = 100f;

        public MovementSystem() : base(new Matcher().all(typeof(CharInput), typeof(Motion)))
        {
        }

        public override void process(Entity entity)
        {
            var inputState = entity.getComponent<CharInput>();

            var moveDir = Vector2.Zero;
            if (inputState.MoveLeft)
            {
                moveDir.X--;
            }

            if (inputState.MoveRight)
            {
                moveDir.X++;
            }

            if (inputState.MoveUp)
            {
                moveDir.Y--;
            }

            if (inputState.MoveDown)
            {
                moveDir.Y++;
            }

            if (moveDir != Vector2.Zero)
            {
                var motion = entity.getComponent<Motion>();
                motion.Direction = moveDir;
                motion.Speed = speed;
            }
        }
    }
}
