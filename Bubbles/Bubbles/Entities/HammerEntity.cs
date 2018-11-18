using System.Linq;
using System.Runtime.InteropServices;
using Bubbles.Systems.Animation;
using Nez.Sprites;
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
    public class AnimatedHammerEntity : AnimatedEntity<AnimateComboSystem.Animations>
    {
        public AnimatedHammerEntity(string name) : base(name)
        {
            Initialise("hammer", 192);
            
            var swing = SubTextures.Skip(1).ToList();
            swing.Add(SubTextures[3]);
            swing.Add(SubTextures[2]);
            swing.Add(SubTextures[1]);
            
            AddAnimation(new Animation(swing, AnimateComboSystem.Animations.Swing, loop: false));
            AddAnimation(new Animation(SubTextures[0], AnimateComboSystem.Animations.Idle));
        }

        public override void onAddedToScene()
        {
            addComponent(new PlayerControlled());
            addComponent(new Weapon());
            addComponent(new MeleeInput());
            addComponent(new RotateTowardsMouse());
            addComponent(new TransformLock());

            var collider = addComponent(new SpriteCollider<AnimateComboSystem.Animations>());

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

            collider.AddAction(AnimateComboSystem.Animations.Swing, 8, hammer1);
            collider.AddAction(AnimateComboSystem.Animations.Swing, 9, hammer2);
        }
    }
}