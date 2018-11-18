using Bubbles.Components;
using Bubbles.Components.Combat;
using Bubbles.Graphics.Colour;
using Bubbles.Layers;
using Bubbles.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;

namespace Bubbles.Entities
{
    public class EnemyEntity : AnimatedEntity<AnimateMovementSystem.Animations>
    {
        public EnemyEntity(string name) : base(name)
        {    
            var texture2D = Core.content.Load<Texture2D>("player");
            var recolour = Palette.RecolourTexture(texture2D, Palette.Progressions.Blue, Palette.Progressions.Green);
            Initialise(recolour, 32);
                        
            addComponent(new Enemy());
            addComponent(new Health());
//            addComponent(new TweenMotion(1.5f));

            var collider = addComponent(new CircleCollider(8f));
            collider.setLocalOffset(new Vector2(0, 15f));
            Flags.setFlagExclusive(ref collider.physicsLayer, PhysicsLayers.ENEMY);
            Flags.setFlagExclusive(ref collider.collidesWithLayers, PhysicsLayers.PLAYER_WEAPON);
        }
    }
}