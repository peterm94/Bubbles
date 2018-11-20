using System;
using Bubbles.Components;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Systems.Visuals
{
    public class FlashWhiteSystem : EntityProcessingSystem
    {
        private readonly Material _whiteout;
        
        public FlashWhiteSystem(Scene scene) : base(new Matcher().all(typeof(FlashWhite)))
        {
            _whiteout = new Material(scene.content.Load<Effect>("FX/whiteout"));
        }

        public override void process(Entity entity)
        {
            entity.getComponent<Sprite>()?.setMaterial(_whiteout);
            entity.removeComponent<FlashWhite>();
            
            Core.schedule(0.10f, false, this, timer =>
            {
                // This CAN be null if the entity is destroyed before the timeout expires.
                entity?.getComponent<Sprite>()?.setMaterial(Material.defaultMaterial);
                entity?.removeComponent<WontDestroy>();
            });            
        }
    }
}