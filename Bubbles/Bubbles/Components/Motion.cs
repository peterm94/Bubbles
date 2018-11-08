using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Components
{
    public class Motion : Component
    {
        private Vector2 velocity;
        private Vector2 acceleration;


        public void Move(Vector2 vector, float speed)
        {
            entity.position += vector * speed * Time.deltaTime;
        }
    }
}