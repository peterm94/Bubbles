using System;
using Bubbles.Components;
using Bubbles.Entities;
using Bubbles.Util;
using Nez;

namespace Bubbles.Systems
{
    public class EnemySpawnSystem : MultiEntityProcessingSystem
    {
        private readonly MatchedSystem _enemies;

        public EnemySpawnSystem(Scene scene) : base(scene, new Matcher().all(typeof(EnemySpawn)))
        {
            _enemies = InjectEntityMatcher(new Matcher().all(typeof(Enemy)));
        }

        public override void process(Entity entity)
        {
            if (_enemies.Entities().Count < 3)
            {
                entity.getComponents<EnemySpawn>().randomItem().Spawn();
            }
        }
    }
}
