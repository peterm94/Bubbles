using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Bubbles.Player
{
    public class PlayerInput : Component, IUpdatable
    {
        private float speed = 100f;

        public void update()
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

            entity.position += move * speed * Time.deltaTime;
        }
    }
}
