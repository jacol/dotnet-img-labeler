namespace dotnet_img_labeler_lib
{
    public class BoundingBox
    {
        public int X
        {
            get;
            private set;
        }

        public int Y
        {
            get;
            private set;
        }

        public int Width
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public string Label
        {
            get;
            private set;
        }

        public double Confidence
        {
            get;
            private set;
        }

        public BoundingBox(int x, int y, int width, int height, string label, double confidence)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Label = label;
            Confidence = confidence;
        }
    }
}
