using System.IO;
using Bubbles.Components;
using Bubbles.Entities;
using Bubbles.Systems;
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

            addEntity(new PlayerEntity());

            for (int i = 0; i < 10; i++)
            {
                var enemy = createEntity("Enemy");
                enemy.addComponent(new Enemy());
            }

            var cursor = createEntity("Cursor");
            var crosshair = Texture2D.FromStream(Core.graphicsDevice,
                                                 File.OpenRead("../../Content/textures/crosshair.png"));
            cursor.addComponent(new Sprite(crosshair));
            cursor.addComponent(new Cursor());

            addEntityProcessor(new PlayerInputSystem());
            addEntityProcessor(new MovementSystem());
            addEntityProcessor(new EntityMousePositionSystem());
            addEntityProcessor(new PhysicsSystem());
            addEntityProcessor(new HeadTowardsEntitySystem(new Matcher().all(typeof(Player)), cursor));
            addEntityProcessor(new TestMultiSystem(this));
        }
    }
}
