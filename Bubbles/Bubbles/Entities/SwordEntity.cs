using Bubbles.Systems;
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
            var texture = Core.content.Load<Texture2D>("sword");
            var subTextures = Subtexture.subtexturesFromAtlas(texture, 64, 64);

            var sprite = addComponent(new Sprite<AnimateMeleeSystem.Animations>(subTextures[0]));
            
            var swingAnim = new SpriteAnimation(subTextures);
            swingAnim.setFps(6);
            
            var idleAnim = new SpriteAnimation(subTextures[0]);

            sprite.addAnimation(AnimateMeleeSystem.Animations.Swing, swingAnim);
            sprite.addAnimation(AnimateMeleeSystem.Animations.Idle, idleAnim);
        }
    }
}