using dotnet_img_labeler_lib;
using NUnit.Framework;
using System.Drawing;

namespace dotnet_img_labeler_tests
{    
    public class ColorPickerTests
    {
        private ColorPicker _picker;

        public ColorPickerTests()
        {
            _picker = new ColorPicker();
        }

        [Test]        
        public void GetRandomColor_ColorsFetched([Values(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10)] int x)
        {
            var result = _picker.GetRandomColor();
            Assert.IsAssignableFrom<Color>(result, "Returned object is invalid, expected Color");
        }


        [Test]
        public void GetNextColor_5Times_ColorsFetched([Values(0, 1, 2, 3, 4)] int x)
        {
            var result = _picker.GetNextColor();

            switch (x)
            {
                case 0:
                    Assert.AreEqual(Color.Khaki, result);
                    break;
                case 1:
                    Assert.AreEqual(Color.Fuchsia, result);
                    break;
                case 2:
                    Assert.AreEqual(Color.Silver, result);
                    break;
                case 3:
                    Assert.AreEqual(Color.RoyalBlue, result);
                    break;
                case 4:
                    Assert.AreEqual(Color.Green, result);
                    break;
                default:
                    Assert.Fail("Unexpected color index");
                    break;
            }

            Assert.IsAssignableFrom<Color>(result, "Returned object is invalid, expected Color");
        }

    }
}