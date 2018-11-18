using System.Linq;
using Bubbles.Components;
using Bubbles.Layers;
using Bubbles.Systems.Animation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class HammerEntity : Entity
    {
        public HammerEntity() : base("hammer")
        {
            var texture = Core.content.Load<Texture2D>("hammer");
            var subTextures = Subtexture.subtexturesFromAtlas(texture, 192, 192);

            var sprite = addComponent(new Sprite<AnimateMeleeSystem.Animations>(subTextures[0]));

            var warmUpTextures = subTextures.GetRange(1, 3);
            var coolDownTextures = subTextures.GetRange(1, 3);
            coolDownTextures.Reverse();
            
            var swingTextures = subTextures.Skip(4).ToList();
            var swing = new SpriteAnimation(swingTextures);

            swing.setLoop(false);
            swing.setFps(12);
//            swing.setFps(1);

            var idle = new SpriteAnimation(subTextures[0]);

            sprite.addAnimation(AnimateMeleeSystem.Animations.Swing, swing);
            sprite.addAnimation(AnimateMeleeSystem.Animations.Idle, idle);

            addComponent(new PlayerControlled());
            addComponent(new Weapon());
            addComponent(new MeleeInput());
            addComponent(new RotateTowardsMouse());
            addComponent(new TransformLock());

            var collider = addComponent(new SpriteCollider<AnimateMeleeSystem.Animations>());


            var hammer1 = new PolygonCollider(new[]
            {
                new Vector2(-35f, 8f),
                new Vector2(-36f, -19f),
                new Vector2(-16f, -36f),
                new Vector2(11f, -36f),
                new Vector2(21f, -26f),
                new Vector2(21f, -16f),
                new Vector2(-1f, -26f),
                new Vector2(-20f, -8f),
                new Vector2(-22f, 10f)
            }) {isTrigger = true};

            var hammer2 = new PolygonCollider(new[]
            {
                new Vector2(22f, 6f),
                new Vector2(31f, 15f),
                new Vector2(7f, 34f),
                new Vector2(-16f, 32f),
                new Vector2(-29f, 9f),
                new Vector2(-23f, -19f),
                new Vector2(-18f, -16f),
                new Vector2(-20f, 12f),
                new Vector2(1f, 20f)
            }) {isTrigger = true};

            Flags.setFlagExclusive(ref hammer1.collidesWithLayers, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref hammer1.physicsLayer, PhysicsLayers.PLAYER_WEAPON);
            Flags.setFlagExclusive(ref hammer2.collidesWithLayers, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref hammer2.physicsLayer, PhysicsLayers.PLAYER_WEAPON);

            collider.AddAction(AnimateMeleeSystem.Animations.Swing, 8, hammer1);
            collider.AddAction(AnimateMeleeSystem.Animations.Swing, 9, hammer2);
        }
    }
}
