using System;

namespace Bubbles
{
    internal static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            using (var game = new Main())
            {
                game.Run();
            }
        }
    }
}