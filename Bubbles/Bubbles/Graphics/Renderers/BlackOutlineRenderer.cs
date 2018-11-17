using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;

namespace Bubbles.Graphics.Renderers
{
    public class BlackOutlineRenderer : DefaultRenderer
    {
        public BlackOutlineRenderer(int renderOrder = 0, Camera camera = null) : base(renderOrder, camera)
        {
        }

        public override void render(Scene scene)
        {
            for (var i = 0; i < scene.renderableComponents.count; i++)
            {
                if (scene.renderableComponents[i] is Sprite sprite)
                {
                    var tex = sprite.subtexture.texture2D;
                    var data = new Color[tex.Width * tex.Height];
                    tex.GetData(data);

                    for (var c = 0; c < data.Length; c++)
                    {
                        // If the current pixel is not transparent and
                        // one of the four adjacent pixels is fully transparent.
                        if (data[c].A != 0
                            && (c - 1 >= 0 && data[c - 1].A == 0 ||
                                c + 1 < data.Length && data[c + 1].A == 0 ||
                                c - tex.Width >= 0 && data[c - tex.Width].A == 0 ||
                                c + tex.Width < data.Length && data[c + tex.Width].A == 0))
                        {
                            // Black.
//                            data[c].PackedValue = 4294967295;
                            // Red.
//                            data[c].R = 255;
                            data[c].PackedValue = 4278190335;
                        }
                    }

                    tex.SetData(data);
                }
            }

            base.render(scene);
        }
    }
}