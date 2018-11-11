using Bubbles.Components;
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

            inputState.Clear();

            if (Input.isKeyDown(Keys.A))
                inputState.MoveLeft = true;

            if (Input.isKeyDown(Keys.D))
                inputState.MoveRight = true;

            if (Input.isKeyDown(Keys.W))
                inputState.MoveUp = true;

            if (Input.isKeyDown(Keys.S))
                inputState.MoveDown = true;
        }
    }
}