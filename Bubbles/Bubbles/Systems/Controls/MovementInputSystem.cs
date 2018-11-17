using Bubbles.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Bubbles.Systems.Controls
{
    public class MovementInputSystem : EntityProcessingSystem
    {
        public MovementInputSystem() : base(new Matcher().all(typeof(PlayerControlled),
                                                              typeof(MovementInput)))
        {
        }

        public override void process(Entity entity)
        {
            var inputState = entity.getComponent<MovementInput>();

            var inputVector = Vector2.Zero;

            if (Input.isKeyDown(Keys.A))
                inputVector.X--;

            if (Input.isKeyDown(Keys.D))
                inputVector.X++;

            if (Input.isKeyDown(Keys.W))
                inputVector.Y--;

            if (Input.isKeyDown(Keys.S))
                inputVector.Y++;

            inputState.SetMove(inputVector);
        }
    }
}