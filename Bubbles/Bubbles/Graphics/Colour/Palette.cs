using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;

namespace Bubbles.Graphics.Colour
{
    public static class Palette
    {
        // Preset colour progressions.

        /// <summary>
        ///     Recolour the input Texture2D given input and output colour mappings.
        ///     Each pixel matching an input colour will be mapped to that index from the output colour array.
        /// </summary>
        /// <param name="texture">The texture to recolour.</param>
        /// <param name="input">The input colour progression.</param>
        /// <param name="output">The output colour progression.</param>
        /// <param name="copy">Whether to modify the given texture or create a copy.</param>
        /// <returns>The recoloured texture.</returns>
        public static Texture2D RecolourTexture(Texture2D texture, Color[] input, Color[] output,
                                                bool copy = true)
        {
            var data = new Color[texture.Width * texture.Height];
            texture.GetData(data);

            for (var c = 0; c < data.Length; c++)
            {
                if (data[c].A == 0) continue;

                var index = Array.IndexOf(input, data[c]);

                if (index >= 0)
                {
                    data[c] = output[index];
                }
            }

            if (copy)
            {
                var newTex = new Texture2D(Core.graphicsDevice, texture.Width, texture.Height);
                newTex.SetData(data);
                return newTex;
            }

            texture.SetData(data);
            return texture;
        }

        /// <summary>
        ///     All colours available in the EDG32 colour palette.
        /// </summary>
        public static class Colours
        {
            public static Color RedBrown_2 = new Color(190, 74, 47);
            public static Color RedBrown_1 = new Color(215, 118, 67);
            public static Color Brown_1 = new Color(234, 212, 170);
            public static Color Brown_2 = new Color(228, 166, 114);
            public static Color Brown_3 = new Color(184, 111, 80);
            public static Color Brown_4 = new Color(115, 62, 57);
            public static Color Brown_5 = new Color(62, 39, 49);
            public static Color Red_2 = new Color(162, 38, 51);
            public static Color Red_1 = new Color(228, 59, 68);
            public static Color Orange_2 = new Color(247, 118, 34);
            public static Color Orange_1 = new Color(254, 174, 52);
            public static Color Yellow = new Color(254, 231, 97);
            public static Color Green_1 = new Color(99, 199, 77);
            public static Color Green_2 = new Color(62, 137, 72);
            public static Color Green_3 = new Color(38, 92, 66);
            public static Color Green_4 = new Color(25, 60, 62);
            public static Color Blue_3 = new Color(18, 78, 137);
            public static Color Blue_2 = new Color(0, 149, 233);
            public static Color Blue_1 = new Color(44, 232, 245);
            public static Color White = new Color(255, 255, 255);
            public static Color Grey_1 = new Color(192, 203, 220);
            public static Color Grey_2 = new Color(139, 155, 180);
            public static Color Grey_3 = new Color(90, 105, 136);
            public static Color Grey_4 = new Color(58, 68, 102);
            public static Color Grey_5 = new Color(38, 43, 68);
            public static Color Black = new Color(24, 20, 37);
            public static Color Pink = new Color(255, 0, 68);
            public static Color Purple_2 = new Color(104, 56, 108);
            public static Color Purple_1 = new Color(181, 80, 136);
            public static Color Salmon = new Color(246, 117, 122);
            public static Color Skin_1 = new Color(232, 183, 150);
            public static Color Skin_2 = new Color(194, 133, 105);
        }

        /// <summary>
        ///     Colour progressions. Used to recolour sprites.
        /// </summary>
        public static class Progressions
        {
            public static Color[] Grey = {Colours.Grey_5, Colours.Grey_3, Colours.Grey_2, Colours.Grey_1};
            public static Color[] Blue = {Colours.Grey_5, Colours.Blue_3, Colours.Blue_2, Colours.Blue_1};
            public static Color[] Green = {Colours.Grey_5, Colours.Green_3, Colours.Green_2, Colours.Green_1};
            public static Color[] Fire = {Colours.Brown_5, Colours.Red_2, Colours.Orange_2, Colours.Yellow};
        }
    }
}