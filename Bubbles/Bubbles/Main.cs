using System.IO;
using Bubbles.Components;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles
{
    public class Main : Core
    {
        public Main() : base(width: 1920, height: 1080, windowTitle: "Bubbles")
        {
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);
            base.Draw(gameTime);
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            // Game-wide defaults.
            Scene.setDefaultDesignResolution(512, 288, Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
            
            // http://prime31.github.io/Nez/documentation/systems/physics-collisions
            // Choosing a size that is slightly larger than your average player/enemy size usually works best.
            Physics.spatialHashCellSize = 64;
            
            Window.AllowUserResizing = true;

            var newScene = Scene.createWithDefaultRenderer(Color.Aquamarine);

            LoadScene(newScene);

            scene = newScene;
        }

        private static void LoadScene(Scene newScene)
        {
            var player = newScene.createEntity("Player");
            var tex = Texture2D.FromStream(graphicsDevice, File.OpenRead("../../Content/textures/player.png"));
            player.addComponent(new Sprite(tex));
            player.addComponent(new Player());
            player.transform.position = new Vector2(256, 144);
            
            var cursor = newScene.createEntity("Cursor");
            var crosshair = Texture2D.FromStream(graphicsDevice, File.OpenRead("../../Content/textures/crosshair.png"));
            cursor.addComponent(new Sprite(crosshair));
            cursor.addComponent(new Cursor());
            
            newScene.addEntityProcessor(new PlayerMovement());
            newScene.addEntityProcessor(new CursorPosition());
        }
    }
}