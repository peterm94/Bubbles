using System.IO;
using Bubbles.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles
{
    public class Main : Core
    {
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);
            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();

            Window.AllowUserResizing = true;

            var newScene = Scene.createWithDefaultRenderer(Color.Aquamarine);

            LoadScene(newScene);

            scene = newScene;
        }

        private void LoadScene(Scene newScene)
        {
            var player = newScene.createEntity("Player");
            var tex = Texture2D.FromStream(graphicsDevice, File.OpenRead("../../Content/textures/player.png"));
            player.addComponent(new Sprite(tex));
            player.addComponent(new PlayerInput());
            player.transform.position = new Vector2(200, 200);
        }
    }
}
