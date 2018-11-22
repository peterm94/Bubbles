using Bubbles.Components;
using Bubbles.Components.Combat;
using Bubbles.Components.Visuals;
using Bubbles.Layers;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.UI;

namespace Bubbles.Entities
{
    public class PlayerEntity : AnimatedEntity<AnimateMovementSystem.Animations>
    {
        public PlayerEntity() : base("Player")
        {
        }

        public override void onAddedToScene()
        {
            setTag(Tags.Player);

            Initialise("player", 32);

            AddAnimation(new Animation(SubTextures, AnimateMovementSystem.Animations.Walk, 6, true));
            AddAnimation(new Animation(SubTextures[0], AnimateMovementSystem.Animations.Idle));

            addComponent(new Player());
            addComponent(new Health());
            addComponent(new PlayerControlled());
            addComponent(new MovementInput());
            addComponent(new MeleeInput());
            addComponent(new Motion());
            addComponent(new HealthBar());

            transform.position = new Vector2(256, 144);

            var collider = addComponent(new CircleCollider(8f));
            collider.setLocalOffset(new Vector2(0, 15f));
            Flags.setFlagExclusive(ref collider.physicsLayer, PhysicsLayers.PLAYER);
            Flags.setFlagExclusive(ref collider.collidesWithLayers, PhysicsLayers.NONE);
        }
    }
}
