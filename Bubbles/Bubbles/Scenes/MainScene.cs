using Bubbles.Components;
using Bubbles.Components.Camera;
using Bubbles.Components.Combat;
using Bubbles.Entities;
using Bubbles.Systems;
using Bubbles.Systems.Animation;
using Bubbles.Systems.Combat;
using Bubbles.Systems.Controls;
using Bubbles.Systems.Position;
using Bubbles.Systems.Visuals;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Scenes
{
    public class MainScene : Scene
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;

        public override void initialize()
        {
            addRenderer(new ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER));
            addRenderer(new RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));

            var cursor = addEntity(new CursorEntity());

            var player = new PlayerEntity();
            addEntity(player);

            var weapon = new HammerEntity("hammer");
            weapon.setPosition(new Vector2(0, 16));
            weapon.setParent(player);
            weapon.addComponent(new RotateTowards {Towards = cursor});
            weapon.addComponent(new PlayerControlled());
            addEntity(weapon);


            var sword1 = new SwordEntity("sword1");
            var enemy1 = addEntity(new EnemyEntity("dude1"));
            enemy1.addComponent(new Equipped {Equip = sword1});
            sword1.setPosition(0, 16);
            sword1.setParent(enemy1);
            sword1.addComponent(new RotateTowards {Towards = player});
            addEntity(sword1);
            enemy1.setPosition(new Vector2(50, 50));

            var sword2 = new SwordEntity("sword2");
            var enemy2 = addEntity(new EnemyEntity("dude2"));
            enemy2.addComponent(new Equipped {Equip = sword2});
            enemy2.setPosition(new Vector2(300, 200));
            sword2.setPosition(0, 16);
            sword2.setParent(enemy2);
            sword2.addComponent(new RotateTowards {Towards = player});
            addEntity(sword2);

            camera.addComponent(new GoodFollowCam(player, cursor));

            addEntityProcessor(new MovementInputSystem());
            addEntityProcessor(new MeleeInputSystem());
            addEntityProcessor(new MovementSystem());
            addEntityProcessor(new TrackMouseSystem());
            addEntityProcessor(new PhysicsSystem());
            addEntityProcessor(new AnimateMovementSystem());
            addEntityProcessor(new AnimateHammerSystem());
            addEntityProcessor(new AnimateMeleeSystem());
//            addEntityProcessor(new HeadTowardsEntitySystem(new Matcher().all(typeof(Player)), cursor));
            addEntityProcessor(new RotateTowardsEntitySystem());
            addEntityProcessor(new ChargeEntitySystem(player));
            addEntityProcessor(new DealDamageSystem());
            addEntityProcessor(new BringOutYourDead());
            addEntityProcessor(new DestroyEntitySystem());
            addEntityProcessor(new FlashWhiteSystem(this));

//            addRenderer(new BlackOutlineRenderer(1000, camera));
        }
    }
}
