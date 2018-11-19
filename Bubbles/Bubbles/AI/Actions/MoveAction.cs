using System;
using Bubbles.Components;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.AI
{
    public class MoveAction : RunnableAction
    {
        public MoveAction() : base("Move")
        {
        }

        public override void Run(Entity entity)
        {
            var movement = entity.getComponent<MovementInput>();
            var heading = entity.getComponent<Heading>();
            
            var move = new Vector2((float) Math.Cos(heading.Value), (float) Math.Sin(heading.Value));
            movement?.SetMove(move);
            
        }
    }
}