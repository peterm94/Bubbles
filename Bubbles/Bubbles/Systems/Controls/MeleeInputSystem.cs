using Bubbles.Components;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Bubbles.Systems.Controls
{
    public class MeleeInputSystem : EntityProcessingSystem
    {
        public MeleeInputSystem() : base(new Matcher().all(typeof(PlayerControlled),
                                                           typeof(Weapon),
                                                           typeof(MeleeInput)))
        {
        }

        public override void process(Entity entity)
        {
            var inputState = entity.getComponent<MeleeInput>();

            inputState.Clear();

            if (Input.leftMouseButtonDown || Input.isKeyDown(Keys.E))
                inputState.Swing = true;
        }
    }
}