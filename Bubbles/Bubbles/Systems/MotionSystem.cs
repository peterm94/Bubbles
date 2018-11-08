using System;
using Bubbles.Components;
using Nez;

namespace Bubbles.Systems
{
    /// <summary>
    ///     Move entities with a Motion component.
    /// </summary>
    public class MotionSystem : EntityProcessingSystem
    {
        public MotionSystem() : base(new Matcher().all(typeof(Motion)))
        {
        }

        public override void process(Entity entity)
        {
            var motion = entity.getComponent<Motion>();

            if (Util.FloatEquals(motion.Speed, 0)) return;

            entity.position += motion.Direction * motion.Speed * Time.deltaTime;

            motion.Speed = Math.Max(motion.Speed - (motion.Friction * Time.deltaTime), 0);
            Console.WriteLine(motion.Speed);
        }
    }
}