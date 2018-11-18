using System;
using Nez;

namespace Bubbles.Components
{
    public class EnemyDamager : Component, ITriggerListener
    {
        public void onTriggerEnter(Collider other, Collider local)
        {
            Console.WriteLine("HIT " + other.entity.name);
        }

        public void onTriggerExit(Collider other, Collider local)
        {
            Console.WriteLine("exit HIT");
        }
    }
}