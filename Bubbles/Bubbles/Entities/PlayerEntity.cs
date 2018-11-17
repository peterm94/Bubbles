using Bubbles.Components;
using Bubbles.Layers;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity() : base("Player")
        {
        }

        public override void onAddedToScene()
        {
            // Load the textures in
            var tex = Core.content.Load<Texture2D>("player");
            var subTextures = Subtexture.subtexturesFromAtlas(tex, 32, tex.Height);

            // Create the sprite component with the first frame loaded by default.
            var sprite = addComponent(new Sprite<AnimateMovementSystem.Animations>(subTextures[0]));

            // Register the walk animation and start it
            var walkAnim = new SpriteAnimation(subTextures);
            walkAnim.setFps(6);
            var idleAnim = new SpriteAnimation(subTextures[0]);
            sprite.addAnimation(AnimateMovementSystem.Animations.Walk, walkAnim);
            sprite.addAnimation(AnimateMovementSystem.Animations.Idle, idleAnim);

            addComponent(new Player());
            addComponent(new PlayerControlled());
            addComponent(new MovementInput());
            addComponent(new MeleeInput());
            addComponent(new Motion());
            transform.position = new Vector2(256, 144);

            var collider = addComponent(new CircleCollider(8f));
            collider.setLocalOffset(new Vector2(0, 15f));
            Flags.setFlagExclusive(ref collider.physicsLayer, PhysicsLayers.PLAYER);
            Flags.setFlagExclusive(ref collider.collidesWithLayers, PhysicsLayers.NONE);
        }
    }
}