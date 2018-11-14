using System.Collections.Generic;
using Nez;

namespace Bubbles.Util
{
    /// <summary>
    ///     Entity system that allows for other entity types to be referenced while processing.
    /// </summary>
    public abstract class MultiEntityProcessingSystem : EntityProcessingSystem
    {
        private readonly Scene _init_scene;

        protected MultiEntityProcessingSystem(Scene scene, Matcher matcher) : base(matcher)
        {
            _init_scene = scene;
        }

        protected MatchedSystem InjectEntityMatcher(Matcher entityMatcher)
        {
            var system = new MatchedSystem(entityMatcher);
            _init_scene.addEntityProcessor(system);
            return system;
        }
    }

    public class MatchedSystem : EntitySystem
    {
        public MatchedSystem(Matcher matcher) : base(matcher)
        {
        }

        public List<Entity> Entities()
        {
            return _entities;
        }
    }
}