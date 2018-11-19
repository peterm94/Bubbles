using Bubbles.Components;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Entities
{
    public class CursorEntity : Entity
    {
        public CursorEntity() : base("Cursor")
        {
        }

        public override void onAddedToScene()
        {
            var tex = Core.content.Load<Texture2D>("crosshair");

            addComponent(new Sprite(tex));
            addComponent(new Cursor());
        }
    }
}