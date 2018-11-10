using Bubbles.Components;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Bubbles.Systems
{
    public class PlayerInputSystem : EntityProcessingSystem
    {
        public PlayerInputSystem() : base(new Matcher().all(typeof(PlayerControlled), typeof(CharInput)))
        {
        }

        public override void process(Entity entity)
        {
            var inputState = entity.getComponent<CharInput>();

            inputState.Clear();

            if (Input.isKeyDown(Keys.A))
            {
                inputState.MoveLeft = true;
            }

            if (Input.isKeyDown(Keys.D))
            {
                inputState.MoveRight = true;
            }

            if (Input.isKeyDown(Keys.W))
            {
                inputState.MoveUp = true;
            }

            if (Input.isKeyDown(Keys.S))
            {
                inputState.MoveDown = true;
            }
        }
    }
}
