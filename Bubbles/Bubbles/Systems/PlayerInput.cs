using System;
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
            var moveDir = Vector2.Zero;
            if (Input.isKeyDown(Keys.A))
            {
                moveDir.X--;
            }

            if (Input.isKeyDown(Keys.D))
            {
                moveDir.X++;
            }

            if (Input.isKeyDown(Keys.W))
            {
                moveDir.Y--;
            }

            if (Input.isKeyDown(Keys.S))
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
