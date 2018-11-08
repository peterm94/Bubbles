using Bubbles.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Bubbles.Systems
{
    public class PlayerInput : EntityProcessingSystem
    {
        private const float speed = 100f;

        public PlayerInput() : base(new Matcher().all(typeof(PlayerControlled), typeof(Motion)))
        {
        }

        public override void process(Entity entity)
        {
            var move = Vector2.Zero;
            if (Input.isKeyDown(Keys.A))
            {
                move.X--;
            }

            if (Input.isKeyDown(Keys.D))
            {
                move.X++;
            }

            if (Input.isKeyDown(Keys.W))
            {
                move.Y--;
            }

            if (Input.isKeyDown(Keys.S))
            {
                move.Y++;
            }
            
            entity.getComponent<Motion>().Move(move, speed);
        }
    }
}
