using System.Linq;
using Bubbles.Components;
using Bubbles.Systems;
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
//            addComponent(new BoxCollider(0, 0, 56, 36));
//            addComponent(new BoxCollider());
        }
    }
}
