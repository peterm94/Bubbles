using Bubbles.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class PlayerEntity : Entity
    {
        enum Animations
        {
            Walk
        }

        public PlayerEntity() : base("Player")
        {
            // Load the textures in
            var tex = Core.content.Load<Texture2D>("player");
            var subTextures = Subtexture.subtexturesFromAtlas(tex, 32, tex.Height);

            // Create the sprite component with the first frame loaded by default.
            var sprite = addComponent(new Sprite<Animations>(subTextures[0]));

            // Register the walk animation and start it
            var animation = new SpriteAnimation(subTextures);
            animation.setFps(2);
            sprite.addAnimation(Animations.Walk, animation);
            sprite.play(Animations.Walk);

            addComponent(new Player());
            addComponent(new PlayerControlled());
            addComponent(new Motion());
            transform.position = new Vector2(256, 144);
        }
    }
}
