using Bubbles.Scenes;
using Nez;

namespace Bubbles
{
    public class Main : Nez.Core
    {
        public Main() : base(1920, 1080, windowTitle: "Bubbles")
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Game-wide defaults.
            Scene.setDefaultDesignResolution(512, 288, Scene.SceneResolutionPolicy.NoBorderPixelPerfect);
            IsMouseVisible = false;

            // http://prime31.github.io/Nez/documentation/systems/physics-collisions
            // Choosing a size that is slightly larger than your average player/enemy size usually works best.
            Physics.spatialHashCellSize = 64;

            Window.AllowUserResizing = true;


            scene = new MainScene();
        }
    }
}
