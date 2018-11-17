using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Systems
{
    public class MovementSystem : EntityProcessingSystem
    {
        private const float speed = 100f;

        public MovementSystem() : base(new Matcher().all(typeof(MovementInput), typeof(Motion)))
        {
        }

        public override void process(Entity entity)
        {
            var inputState = entity.getComponent<MovementInput>();

            var moveDir = inputState.MoveVector;

            if (moveDir != Vector2.Zero)
            {
                var motion = entity.getComponent<Motion>();
                motion.Direction = moveDir;
                motion.Speed = speed;
            }
        }
    }
}