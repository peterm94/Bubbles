using System.Linq;
using Bubbles.Components;
using Bubbles.Components.Combat;
using Bubbles.Layers;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles.Entities
{
    public class EnemySpawnController : Entity
    {
        public EnemySpawnController(string name) : base(name)
        {
        }

        public override void onAddedToScene()
        {
            base.onAddedToScene();

            // Configurables
            const int points = 10;
            const float dist = 400f;
            var midPoint = Vector2.Zero;

            var angleInc = 360f / points;

            // Create some spawn points
            for (var i = 0; i < points; i++)
            {
                var x = midPoint.X + dist * Mathf.cos(i * angleInc);
                var y = midPoint.Y + dist * Mathf.sin(i * angleInc);
                addComponent(new EnemySpawn(new Vector2(x, y)));
            }
        }
    }

    public class EnemySpawn : RenderableComponent
    {
        private readonly Vector2 _position;

        public EnemySpawn(Vector2 position)
        {
            _position = position;
        }

        public override RectangleF bounds { get; } = RectangleF.maxRect;

        public override void render(Nez.Graphics graphics, Camera camera)
        {
            if (debugRenderEnabled)
            {
                graphics.batcher.drawCircle(_position, 10f, Color.DarkRed);
            }
        }

        public void Spawn()
        {
            var player = entity.scene.findEntitiesWithTag(Tags.Player).First();

            if (player == null) return;

            // TODO pass this in or something, pick from a list?
            var sword = new SwordEntity("sword1");
            var enemy = entity.scene.addEntity(new EnemyEntity());
            enemy.addComponent(new Equipped {Equip = sword});
            sword.setPosition(0, 16);
            sword.setParent(enemy);
            sword.addComponent(new RotateTowards {Towards = player});
            entity.scene.addEntity(sword);
            enemy.setPosition(_position);
        }
    }
}
