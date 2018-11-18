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
    public class SwordEntity : AnimatedEntity<AnimateMeleeSystem.Animations>
    {
        public SwordEntity(string name) : base(name)
        {
            Initialise("baked-sword", 96);
            AddAnimation(new Animation(SubTextures.Skip(1).ToList(), AnimateMeleeSystem.Animations.Swing));
            AddAnimation(new Animation(SubTextures[0], AnimateMeleeSystem.Animations.Idle));

            addComponent(new PlayerControlled());
            addComponent(new Weapon());
            addComponent(new MeleeInput());
            addComponent(new RotateTowardsMouse());
            addComponent(new TransformLock());

            var collider = addComponent(new SpriteCollider<AnimateMeleeSystem.Animations>());
            var swordCollider = new PolygonCollider(new[]
            {
                new Vector2(-32f, 2f),
                new Vector2(-23f, 22f),
                new Vector2(-9f, 31f),
                new Vector2(8f, 30f),
                new Vector2(23f, 21f),
                new Vector2(17f, 3f),
                new Vector2(-14f, 10f)
            });

            Flags.setFlagExclusive(ref swordCollider.collidesWithLayers, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref swordCollider.physicsLayer, PhysicsLayers.PLAYER_WEAPON);
            swordCollider.isTrigger = true;
            collider.AddAction(AnimateMeleeSystem.Animations.Swing, 0, swordCollider);
        }
    }
}
