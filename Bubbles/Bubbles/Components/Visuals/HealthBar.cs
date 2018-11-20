using Bubbles.Components.Combat;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components.Visuals
{

    public class HealthBar : RenderableComponent
    {
        private const int BarHeight = 2;
        private const int BarWidth = 30;
        private readonly Vector2 _targetOffset = new Vector2(-1 * (BarWidth / 2), 25);
        
        public override RectangleF bounds { get; } = RectangleF.maxRect;
        private readonly Entity _target;
        
        public HealthBar(Entity target)
        {
            _target = target;
        }
        
        public override void render(Nez.Graphics graphics, Nez.Camera camera)
        {
            // TODO figure out the height of the target dynamically.
            var barPos = _target.position + _targetOffset;
            var health = _target.getComponent<Health>();
            if (health != null)
            {
                var healthWidth = (float)health.Hp / health.MaxHp * BarWidth;
                
                graphics.batcher.drawRect(barPos, BarWidth, BarHeight, Color.Red);
                graphics.batcher.drawRect(barPos, healthWidth, BarHeight, Color.Chartreuse);
            }
        }
    }
}