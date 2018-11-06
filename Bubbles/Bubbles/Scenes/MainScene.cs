using System.IO;
using Bubbles.Components;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace Bubbles.Scenes
{
    public class MainScene : Scene
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;

        public override void initialize()
        {
            base.initialize();

            addRenderer(new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER));
            addRenderer(new RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));

            var player = createEntity("Player");
            var tex = Texture2D.FromStream(Core.graphicsDevice, File.OpenRead("../../Content/textures/player.png"));
            player.addComponent(new Sprite(tex));
            player.addComponent(new Player());
            player.transform.position = new Vector2(256, 144);

            var cursor = createEntity("Cursor");
            var crosshair =
                Texture2D.FromStream(Core.graphicsDevice, File.OpenRead("../../Content/textures/crosshair.png"));
            cursor.addComponent(new Sprite(crosshair));
            cursor.addComponent(new Cursor());

            addEntityProcessor(new PlayerMovement());
            addEntityProcessor(new CursorPosition());
        }
    }
}
