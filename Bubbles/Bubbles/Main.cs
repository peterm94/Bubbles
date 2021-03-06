using System;
using System.Drawing.Drawing2D;
using System.Security.Principal;
using Bubbles.Scenes;
using Bubbles.Util;
using Microsoft.Xna.Framework;
using Nez;

namespace Bubbles
{
    public class Main : Core
    {
        public Main() : base(1920, 1080)
        {
//            Screen.synchronizeWithVerticalRetrace = false;
//            TargetElapsedTime = TimeSpan.FromSeconds(1d / 144d);
//            Screen.applyChanges();
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

            debugRenderEnabled = true;

            Window.AllowUserResizing = true;

            // Register custom actions
            var actions = new CustomDebugActions(this);

            scene = new MainScene();
        }
    }
}
