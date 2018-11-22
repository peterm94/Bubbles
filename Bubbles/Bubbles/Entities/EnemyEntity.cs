using Bubbles.AI.Agents;
using Bubbles.AI.Boilerplate;
using Bubbles.Components;
using Bubbles.Components.Combat;
using Bubbles.Components.Visuals;
using Bubbles.Graphics.Colour;
using Bubbles.Layers;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Bubbles.Entities
{
    public class EnemyEntity : AnimatedEntity<AnimateMovementSystem.Animations>
    {
        private static int _entityC;

        public EnemyEntity(string name) : base(name)
        {
        }

        public EnemyEntity() : base("enemy" + ++_entityC)
        {
        }

        public override void onAddedToScene()
        {
            var texture2D = Core.content.Load<Texture2D>("player");
            var recolour = Palette.RecolourTexture(texture2D, Palette.Progressions.Blue, Palette.Progressions.Green);

            Initialise(recolour, 32);

            AddAnimation(new Animation(SubTextures, AnimateMovementSystem.Animations.Walk, 6, true));
            AddAnimation(new Animation(SubTextures[0], AnimateMovementSystem.Animations.Idle));

            addComponent(new Enemy());
            addComponent(new Health());
            addComponent(new Heading());
            addComponent(new MovementInput());
            addComponent(new Motion {SpeedMultiplier = 0.5f});
            addComponent(new HealthBar());
            addComponent(new GOAPStateMachine(new EnemyAgent(this)));

            var collider = addComponent(new CircleCollider(8f));
            collider.setLocalOffset(new Vector2(0, 15f));
            Flags.setFlagExclusive(ref collider.physicsLayer, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref collider.collidesWithLayers, PhysicsLayers.PLAYER_WEAPON);
        }
    }
}
