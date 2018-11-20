using Nez;

namespace Bubbles.Components.Combat
{
    public class Health : Component
    {
        public short Hp { get; set; } = 100;
        public short MaxHp { get; }

        public Health(short maxHp = 100)
        {
            MaxHp = maxHp;
        }
    }
}