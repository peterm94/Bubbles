using Nez;

namespace Bubbles.Components
{
    public class MeleeInput : Component
    {
        public bool Swing { get; set; }

        public void Clear()
        {
            Swing = false;
        }
    }
}