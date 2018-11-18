using System.Threading;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Components
{
    public class Player : Component
    {
    }

    public class PlayerControlled : Component
    {
    }

    public class Cursor : Component
    {
    }

    public class Enemy : Component
    {
    }

    public class RotateTowardsMouse : Component
    {
    }

    public class Weapon : Component
    {
    }

    public class Sleep : Component
    {
        public int Timeout { get; set; }
    }

    public class Attacked : Component
    {
        public Attacked(Collider hitter)
        {
            Hitter = hitter;
        }

        public Collider Hitter { get; }

        public override void onAddedToEntity()
        {
            entity.addComponent(new FlashWhite());
        }
    }

    public class FlashWhite : Component
    {
        public override void onAddedToEntity()
        {
            var whiteout = entity.scene.content.Load<Effect>("FX/whiteout");
            entity.getComponent<Sprite>().setMaterial(new Material(whiteout));

            entity.addComponent(new Sleep {Timeout = 50});
            
            Core.schedule(0.10f, false, this,
                          timer => { entity.getComponent<Sprite>().setMaterial(Material.defaultMaterial); });            
        }
    }
}
