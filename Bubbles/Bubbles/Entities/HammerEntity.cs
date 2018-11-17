using System.Linq;
using Bubbles.Components;
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

            var swingTextures = subTextures.Skip(1).ToList();
            swingTextures.Add(subTextures[3]);
            swingTextures.Add(subTextures[2]);
            swingTextures.Add(subTextures[1]);

            var swing = new SpriteAnimation(swingTextures);

            swing.setLoop(false);
            swing.setFps(12);
            
            var idle = new SpriteAnimation(subTextures[0]);

            sprite.addAnimation(AnimateMeleeSystem.Animations.Swing, swing);
            sprite.addAnimation(AnimateMeleeSystem.Animations.Idle, idle);
            
            addComponent(new PlayerControlled());
            addComponent(new Weapon());
            addComponent(new MeleeInput());
            addComponent(new RotateTowardsMouse());
            addComponent(new TransformLock());
        }
    }
}