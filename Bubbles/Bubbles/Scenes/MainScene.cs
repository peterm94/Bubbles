using System.IO;
using Bubbles.Components;
using Bubbles.Entities;
using Bubbles.Systems;
using Bubbles.Systems.Position;
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

            var player = new PlayerEntity();
            addEntity(player);

            var sword = new SwordEntity();
            var wielder = new Equipped {Wielder = player, Offset = new Vector2(28, 16)};
            sword.addComponent(wielder);
            addEntity(sword);

            addEntity(new CursorEntity());
            
            for (int i = 0; i < 10; i++)
            {
                var enemy = createEntity("Enemy");
                enemy.addComponent(new Enemy());
            }

            addEntityProcessor(new PlayerInputSystem());
            addEntityProcessor(new MovementSystem());
            addEntityProcessor(new TrackMouseSystem());
            addEntityProcessor(new TrackEquippedSystem());
            addEntityProcessor(new PhysicsSystem());
            addEntityProcessor(new AnimateMovementSystem());
//            addEntityProcessor(new HeadTowardsEntitySystem(new Matcher().all(typeof(Player)), cursor));
            addEntityProcessor(new TestMultiSystem(this));
        }
    }
}
