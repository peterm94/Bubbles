using System.Collections.Generic;
using Nez;

namespace Bubbles
{
    /// <summary>
    ///     Entity system that allows for other entity types to be referenced while processing.
    /// </summary>
    public abstract class MultiEntityProcessingSystem : EntitySystem
    {
        private readonly Dictionary<string, MatchedSystem> _systems = new Dictionary<string, MatchedSystem>();

        /// <summary>
        ///     Create a new processing system.
        /// </summary>
        /// <param name="scene">The scene this system is being created in. Required to register inner matchers.</param>
        /// <param name="matcher">The entity matcher.</param>
        /// <param name="others">Any other entities that should be made available while processing. They will be
        /// referenced by their name in the process loop.</param>
        public MultiEntityProcessingSystem(Scene scene,
                                           Matcher matcher,
                                           Dictionary<string, Matcher> others) : base(matcher)
        {
            foreach (var pair in others)
            {
                var subSystem = new MatchedSystem(pair.Value);
                scene.addEntityProcessor(subSystem);
                _systems.Add(pair.Key, subSystem);
            }
        }

        protected override void process(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                process(entity, _systems);
            }
        }

        protected override void lateProcess(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                lateProcess(entity, _systems);
            }
        }

        protected abstract void process(Entity entity, Dictionary<string, MatchedSystem> others);

        protected virtual void lateProcess(Entity entity, Dictionary<string, MatchedSystem> others)
        {
        }
    }

    public class MatchedSystem : EntitySystem
    {
        public MatchedSystem(Matcher matcher) : base(matcher)
        {
        }

        public List<Entity> getEntities()
        {
            return _entities;
        }
    }
}
