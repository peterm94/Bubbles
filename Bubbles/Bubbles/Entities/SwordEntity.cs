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
    public class SwordEntity : Entity
    {
        public SwordEntity() : base("Sword")
        {
            var texture = Core.content.Load<Texture2D>("baked-sword");
            var subTextures = Subtexture.subtexturesFromAtlas(texture, 96, 96);

            var sprite = addComponent(new Sprite<AnimateMeleeSystem.Animations>(subTextures[0]));

            var swingAnim = new SpriteAnimation(subTextures.Skip(1).ToList());

            swingAnim.setLoop(false);
            swingAnim.setFps(12);

            var idleAnim = new SpriteAnimation(subTextures[0]);

            sprite.addAnimation(AnimateMeleeSystem.Animations.Swing, swingAnim);
            sprite.addAnimation(AnimateMeleeSystem.Animations.Idle, idleAnim);
//            sprite.setOrigin(new Vector2(0, 0));
//            sprite.setLocalOffset(new Vector2(0, 0));

            addComponent(new PlayerControlled());
            addComponent(new Weapon());
            addComponent(new MeleeInput());
            addComponent(new RotateTowardsMouse());
            addComponent(new TransformLock());
//            addComponent(new BoxCollider(0, 0, 56, 36));
//            addComponent(new BoxCollider());

//            var spriteMove = addComponent(new SpriteMove<AnimateMeleeSystem.Animations>());
//            spriteMove.AddAction(AnimateMeleeSystem.Animations.Swing, 0, new MotionInfo(new Vector2(10f, 10f), 10f));

            var collider = addComponent(new SpriteCollider<AnimateMeleeSystem.Animations>());
            var swordColldier = new PolygonCollider(new[]
            {
                new Vector2(-32f, 2f),
                new Vector2(-23f, 22f),
                new Vector2(-9f, 31f),
                new Vector2(8f, 30f),
                new Vector2(23f, 21f),
                new Vector2(17f, 3f),
                new Vector2(-14f, 10f)
            });

//            Flags.setFlagExclusive(ref swordColldier.collidesWithLayers, PhysicsLayers.ENEMY);
//            Flags.setFlagExclusive(ref swordColldier.physicsLayer, PhysicsLayers.PLAYER_WEAPON);
            swordColldier.isTrigger = true;
            collider.AddAction(AnimateMeleeSystem.Animations.Swing, 0, swordColldier);

            addComponent(new EnemyDamager());
        }
    }
}
