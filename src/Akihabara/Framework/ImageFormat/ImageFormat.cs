namespace Akihabara.Framework.ImageFormat
{
    public class ImageFormat
    {
        public enum Format : int
        {
            Unknown = 0,
            Srgb = 1,
            Srgba = 2,
            Gray8 = 3,
            Gray16 = 4,
            Ycbcr420P = 5,
            Ycbcr420P10 = 6,
            Srgb48 = 7,
            Srgba64 = 8,
            Vec32F1 = 9,
            Lab8 = 10,
            Sbgra = 11,
            Vec32F2 = 12,
        }
    }
}
