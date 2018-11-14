using Bubbles.Components;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class EnemyEntity : Entity
    {
        public EnemyEntity() : base("Enemy")
        {
            var tex = Core.content.Load<Texture2D>("player");
            var subTextures = Subtexture.subtexturesFromAtlas(tex, 32, tex.Height);

            // Create the sprite component with the first frame loaded by default.
            var sprite = addComponent(new Sprite<AnimateMovementSystem.Animations>(subTextures[0]));
            sprite.setColor(Color.Red);

            addComponent(new Enemy());

            transform.position = new Vector2(50, 50);
        }
    }
}
