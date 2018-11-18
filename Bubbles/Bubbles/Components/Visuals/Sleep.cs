using System.Threading;
using Nez;

namespace Bubbles.Components
{
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
            Core.schedule(0.0001f * Timeout, timer => entity?.removeComponent(this));
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
}