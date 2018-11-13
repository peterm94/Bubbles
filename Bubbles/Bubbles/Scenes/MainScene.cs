using Bubbles.Components;
using Bubbles.Entities;
using Bubbles.Graphics.Renderers;
using Bubbles.Systems;
using Bubbles.Systems.Animation;
using Bubbles.Systems.Controls;
using Bubbles.Systems.Position;
using Microsoft.Xna.Framework;
using Nez;

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
            sword.setPosition(new Vector2(0, 16));
            sword.setParent(player);
//            sword.addComponent(new RotateTowardsMouse());
            addEntity(sword);
            
            addEntity(new CursorEntity());

            addEntity(new EnemyEntity());

            addEntityProcessor(new MovementInputSystem());
            addEntityProcessor(new MeleeInputSystem());
            addEntityProcessor(new MovementSystem());
            addEntityProcessor(new TrackMouseSystem());
            addEntityProcessor(new PhysicsSystem());
            addEntityProcessor(new AnimateMovementSystem());
            addEntityProcessor(new AnimateMeleeSystem());
//            addEntityProcessor(new HeadTowardsEntitySystem(new Matcher().all(typeof(Player)), cursor));
            addEntityProcessor(new TestMultiSystem(this));
            addEntityProcessor(new RotateTowardsMouseSystem());
//            addEntityProcessor(new ChargeEntitySystem(new Matcher().all(typeof(Enemy)), player));
            
            addRenderer(new BlackOutlineRenderer(1000));
        }
    }
}