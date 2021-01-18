using System;
using System.Drawing;

namespace dotnet_img_labeler_lib
{
    public class ColorPicker
    {
        private readonly Color[] _colors = new Color[]
        {
            Color.Khaki,
            Color.Fuchsia,
            Color.Silver,
            Color.RoyalBlue,
            Color.Green,
            Color.DarkOrange,
            Color.Purple,
            Color.Gold,
            Color.Red,
            Color.Aquamarine,
            Color.Lime,
            Color.AliceBlue,
            Color.Sienna,
            Color.Orchid,
            Color.Tan,
            Color.LightPink,
            Color.Yellow,
            Color.HotPink,
            Color.OliveDrab,
            Color.SandyBrown,
            Color.DarkTurquoise
        };

        private Random _rand;
        private int _lastColorIndex;

        public ColorPicker()
        {
            _rand = new Random();
            _lastColorIndex = 0;
        }

        public Color GetRandomColor()
        {
            return _colors[_rand.Next(0, _colors.Length - 1)];
        }

        public Color GetNextColor()
        {
            var result = _colors[_lastColorIndex++];

            if(_lastColorIndex >= _colors.Length)
            {
                _lastColorIndex = 0;
            }

            return result;
        }
    }
}
