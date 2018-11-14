using System.Linq;
using Bubbles.Components;
using Bubbles.Graphics.Colour;
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
            var texture2D = Core.content.Load<Texture2D>("player");
            var recolour = Palette.RecolourTexture(texture2D, Palette.Progressions.Blue, Palette.Progressions.Green);
            var subTextures = Subtexture.subtexturesFromAtlas(recolour, 32, texture2D.Height);
            
            // Create the sprite component with the first frame loaded by default.
            var sprite = addComponent(new Sprite<AnimateMovementSystem.Animations>(subTextures[0]));
            
            addComponent(new Enemy());

            transform.position = new Vector2(50, 50);
        }
    }
}
