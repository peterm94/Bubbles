using System.Collections.Generic;
using Bubbles.AI;
using Bubbles.Components;
using Bubbles.Components.AI;
using Bubbles.Components.Combat;
using Bubbles.Components.Visuals;
using Bubbles.Graphics.Colour;
using Bubbles.Layers;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.AI.FSM;
using Nez.AI.GOAP;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class EnemyEntity : AnimatedEntity<AnimateMovementSystem.Animations>
    {           
        public EnemyEntity(string name) : base(name)
        {    
        }

        public override void onAddedToScene()
        {
            var texture2D = Core.content.Load<Texture2D>("player");
            var recolour = Palette.RecolourTexture(texture2D, Palette.Progressions.Blue, Palette.Progressions.Green);
            
            Initialise(recolour, 32);
            
            AddAnimation(new Animation(SubTextures, AnimateMovementSystem.Animations.Walk, 6, true));
            AddAnimation(new Animation(SubTextures[0], AnimateMovementSystem.Animations.Idle));
            
            addComponent(new Enemy());
            addComponent(new Health());
            addComponent(new Heading());
            addComponent(new MovementInput());
            addComponent(new Motion {SpeedMultiplier = 0.5f});
            addComponent(new InRange());
            addComponent<EnemyAI>();
            addComponent(new HealthBar(this));
//            addComponent(new TweenMotion(1.5f));

            var collider = addComponent(new CircleCollider(8f));
            collider.setLocalOffset(new Vector2(0, 15f));
            Flags.setFlagExclusive(ref collider.physicsLayer, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref collider.collidesWithLayers, PhysicsLayers.PLAYER_WEAPON);            
        }
    }
}