using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Nez;
using Nez.Console;

namespace Bubbles.Util
{
#if DEBUG
    public class SystemsDebugCommand
    {
        private static void logAllSystems()
        {
            var systems = typeof(EntityProcessorList)
                          .GetField("_processors", BindingFlags.NonPublic | BindingFlags.Instance)
                          ?.GetValue(Core.scene.entityProcessors) as List<EntitySystem>;

            DebugConsole.instance.log("Currently loaded systems:");

            if (systems != null)
            {
                foreach (var entitySystem in systems)
                {
                    var entities = typeof(EntitySystem)
                                   .GetField("_entities", BindingFlags.NonPublic | BindingFlags.Instance)
                                   ?.GetValue(entitySystem) as List<Entity>;
                    DebugConsole.instance.log($"- {entitySystem.GetType().Name} (Entity Count: {entities.Count})");
                }
            }
        }

        [Command("systems",
            "Log information about a entity systems. Provide a specific system name for more information.")]
        private static void logSystemDetails(string systemName)
        {
            if (systemName == null)
            {
                // Log all
                logAllSystems();
                return;
            }

            var asm = Assembly.GetExecutingAssembly();
            var systemType = asm.GetTypes().FirstOrDefault(p => p.Namespace.StartsWith("Bubbles") &&
                                                                p.Name.Contains(systemName));

            if (systemType == null)
            {
                DebugConsole.instance.log($"Could not find system with type '{systemName}'.");
                return;
            }

            var method = typeof(Scene).GetMethod("getEntityProcessor")?.MakeGenericMethod(systemType);

            if (method != null)
            {
                var system = method.Invoke(Core.scene, null);

                var entities = typeof(EntitySystem).GetField("_entities",
                                                             BindingFlags.NonPublic | BindingFlags.Instance)
                                                   ?.GetValue(system) as List<Entity>;
                var entityList = string.Join(", ", entities.Select(x => x.name).ToArray());
                DebugConsole.instance.log($"{system.GetType().Name}" +
                                          $"\n- Entity Count: {entities.Count}" +
                                          $"\n- Entity List: [{entityList}]");
            }
        }
    }
#endif
}
