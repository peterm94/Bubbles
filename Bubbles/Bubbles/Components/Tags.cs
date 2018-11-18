using System;
using System.Net;
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
        private static long _sleepers = 0;
        public int Timeout { get; set; }

        public override void onAddedToEntity()
        {
            // Increment the sleeper count.
            Interlocked.Increment(ref _sleepers);

            // Slow it down.
            Time.timeScale = 0.1f;

            // Schedule the end. Multiply the timeout by 0.0001 (0.001 for milliseconds, and another because the
            // timescale is 0.1).
            Core.schedule(0.0001f * Timeout, timer => entity.removeComponent(this));
        }

        public override void onRemovedFromEntity()
        {
            // Remove from the sleeper count.
            Interlocked.Decrement(ref _sleepers);

            // If nothing else is slowing everything down, change the timescale back.
            if (Interlocked.Read(ref _sleepers) == 0)
            {
                Time.timeScale = 1f;
            }
        }
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
