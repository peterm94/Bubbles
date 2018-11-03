using Microsoft.Xna.Framework;

namespace Bubbles
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);
            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
        }
    }
}
