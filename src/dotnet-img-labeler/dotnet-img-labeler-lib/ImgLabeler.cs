using System.Drawing;
using System.Drawing.Drawing2D;

namespace dotnet_img_labeler_lib
{
    public class ImgLabeler
    {
        private readonly ColorPicker _colorPicker;

        public ImgLabeler(ColorPicker colorPicker)
        {
            this._colorPicker = colorPicker;
        }

        public void AddLabels(string inputImageFilePath, string outputImageFilePath, BoundingBox [] boxesToLabel)
        {
            var inputImage = ReadToImage(inputImageFilePath);
            

            using (Graphics thumbnailGraphic = Graphics.FromImage(inputImage))
            {
                thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
                thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
                thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

                foreach (var box in boxesToLabel)
                {
                    string text = $"{box.Label} ({(box.Confidence * 100).ToString("0")}%)";
                    
                    Font drawFont = new Font("Arial", 12, FontStyle.Bold);
                    SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
                    SolidBrush fontBrush = new SolidBrush(Color.Black);
                    Point atPoint = new Point((int)box.X, (int)box.Y - (int)size.Height - 1);

                    Color color = _colorPicker.GetNextColor();

                    Pen pen = new Pen(color, 3.2f);
                    SolidBrush colorBrush = new SolidBrush(color);

                    thumbnailGraphic.FillRectangle(colorBrush, (int)box.X, (int)(box.Y - size.Height - 1), (int)size.Width, (int)size.Height);
                    thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);                    
                    thumbnailGraphic.DrawRectangle(pen, box.X, box.Y, box.Width, box.Height);

                    inputImage.Save(outputImageFilePath);
                }
            }
        }

        private Image ReadToImage(string filePath)
        {
            return Image.FromFile(filePath);
        }
    }
}
