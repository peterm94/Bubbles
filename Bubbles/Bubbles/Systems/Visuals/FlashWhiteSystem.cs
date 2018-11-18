using System;
using Bubbles.Components;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems.Visuals
{
    public class FlashWhiteSystem : EntityProcessingSystem
    {
        private readonly Effect _whiteout;
        
        public FlashWhiteSystem() : base(new Matcher().all(typeof(FlashWhite)))
        {
            _whiteout = scene.content.Load<Effect>("FX/whiteout");
        }

        public override void process(Entity entity)
        {
            entity.getComponent<Sprite>()?.setMaterial(new Material(_whiteout));
            
            Core.schedule(0.10f, false, this, timer =>
            {
                // This CAN be null if the entity is destroyed before the timeout expires.
                entity?.getComponent<Sprite>()?.setMaterial(Material.defaultMaterial);
            });
            
            entity.removeComponent<FlashWhite>();
        }
    }
}