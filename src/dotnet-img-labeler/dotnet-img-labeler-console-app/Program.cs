using dotnet_img_labeler_lib;
using System;

namespace dotnet_img_labeler_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            ImgLabeler labeler = new ImgLabeler(new ColorPicker());
            labeler.AddLabels("in.jpg", "out.jpg", new BoundingBox[]
            {
                new BoundingBox(100, 100, 400, 400, "Test Label", 0.85d)
            });
        }
    }
}
