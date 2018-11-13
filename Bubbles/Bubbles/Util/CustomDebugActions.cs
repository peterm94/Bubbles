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
        }

        private void ToggleMouse()
        {
            _core.IsMouseVisible = !_core.IsMouseVisible;
        }
    }
}