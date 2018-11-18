using Nez;
using Nez.Console;

namespace Bubbles.Util
{
    public class CustomDebugActions
    {
        private readonly Core _core;

        public CustomDebugActions(Core core)
        {
            _core = core;
            DebugConsole.bindActionToFunctionKey(1, ToggleMouse);
            DebugConsole.bindActionToFunctionKey(2, ToggleDebugDraw);
        }

        private void ToggleDebugDraw()
        {
            Core.debugRenderEnabled = !Core.debugRenderEnabled;
        }

        private void ToggleMouse()
        {
            _core.IsMouseVisible = !_core.IsMouseVisible;
        }
    }
}
