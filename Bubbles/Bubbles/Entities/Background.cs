using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class Background : Entity
    {
        public Background()
        {
            var bg = new Subtexture(Core.content.Load<Texture2D>("StoneFloorTile"));

            for (var i = -256; i < 256; i += 32)
            {
                for (var j = -256; j < 256; j += 32)
                {
                    var sprite = new Sprite(bg) {layerDepth = 1, localOffset = new Vector2(i, j)};
                    addComponent(sprite);
                }
            }
        }
    }
}