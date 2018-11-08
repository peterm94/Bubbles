using System;
using System.IO;
using Bubbles.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Entities
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity() : base("Player")
        {
            var tex = Texture2D.FromStream(Core.graphicsDevice, File.OpenRead("../../Content/textures/player.png"));
            addComponent(new Sprite(tex));
            addComponent(new Player());
            addComponent(new PlayerControlled());
            addComponent(new Motion());
            transform.position = new Vector2(256, 144);
        }
    }
}
