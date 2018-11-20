using System;
using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.AI.Boilerplate
{
    public static class Movement
    {
        public static bool InRange(Entity from, Entity to, int range)
        {
            return Vector2.Distance(from.position, to.position) < range;
        }

        public static void Move(Entity from, Entity to)
        {
            var movement = from.getComponent<MovementInput>();
            
            var dir = Math.Atan2(to.position.Y - from.position.Y,
                                 to.position.X - from.position.X);
            
            var move = new Vector2((float) Math.Cos(dir), (float) Math.Sin(dir));
            movement?.SetMove(move);
        }

        public static void Clear(Entity entity)
        {
            entity.getComponent<MovementInput>().Clear();
        }
    }
}