using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Security.Policy;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    /// <summary>
    /// Base class for all animated entities which hides all required boilerplate.
    /// </summary>
    /// <typeparam name="TKey">The animation key enum to use.</typeparam>
    public abstract class AnimatedEntity<TKey> : Entity where TKey : struct, IComparable, IFormattable
    {   
        protected List<Subtexture> SubTextures;
        protected Sprite<TKey> Sprite;

        protected AnimatedEntity(string name) : base(name)
        {
        }

        protected void Initialise(string spritesheet, int width, int height = -1, int staticFrame = 0)
        {
            Initialise(Core.content.Load<Texture2D>(spritesheet), width, height, staticFrame);
        }

        protected void Initialise(Texture2D spritesheet, int width, int height = -1, int staticFrame = 0)
        {
            // C# is stupid.
            if (height == -1)
            {
                height = spritesheet.Height;
            }
            
            SubTextures = Subtexture.subtexturesFromAtlas(spritesheet, width, height);
            Sprite = new Sprite<TKey>(SubTextures[staticFrame]);
            addComponent(Sprite);
        }

        /// <summary>
        /// Add an animation to the AnimatedEntity.
        /// </summary>
        /// <param name="animation">The animation to add.</param>
        protected void AddAnimation(Animation animation)
        {
            var spriteAnimation = new SpriteAnimation(animation.Frames);
            spriteAnimation.setFps(animation.Fps);
            spriteAnimation.setLoop(animation.Loop);
            Sprite.addAnimation(animation.Key, spriteAnimation);
        }

        /// <summary>
        /// Data class holding everything required to add an animation to the sprite.
        /// </summary>
        protected class Animation
        {            
            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="frames">The frames of the animation.</param>
            /// <param name="key">The animation key.</param>
            /// <param name="fps">The frame rate of the animation.</param>
            /// <param name="loop">Whether to loop the animation.</param>
            public Animation(List<Subtexture> frames, TKey key, int fps = 12, bool loop = true)
            {
                Frames = frames;
                Fps = fps;
                Loop = loop;
                Key = key;
            }
            
            public Animation(Subtexture frame, TKey key, int fps = 12, bool loop = true)
            {
                Frames = new List<Subtexture> {frame};
                Fps = fps;
                Loop = loop;
                Key = key;
            }

            public List<Subtexture> Frames { get; }
            public int Fps { get; }
            public bool Loop { get; }
            public TKey Key { get; }
        }
    }
}