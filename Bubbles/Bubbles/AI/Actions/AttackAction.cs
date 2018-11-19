using System;
using Nez;

namespace Bubbles.AI
{
    public class AttackAction : RunnableAction
    {
        public override void Run(Entity entity)
        {
            
            Console.WriteLine("Attack!");
        }
    }
}