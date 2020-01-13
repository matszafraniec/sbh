using System;
using UIKit;

namespace sbh.Helpers
{
    public static class AppColors
    {
        public static UIColor DarkRed = UIColor.FromRGB((nfloat)(87.0 / 255.0), (nfloat)(23.0 / 255.0),(nfloat)(23.0 / 255.0));
        public static UIColor DarkGray = UIColor.FromRGB((nfloat)(112 / 255.0), (nfloat)(112 / 255.0), (nfloat)(112.0 / 255.0));
        public static UIColor LightGray = UIColor.FromRGB((nfloat)(230.0 / 255.0), (nfloat)(230.0 / 255.0), (nfloat)(230.0 / 255.0));
        public static UIColor WhiteSmoke = UIColor.FromRGB((nfloat)(248.0 / 255.0), (nfloat)(248.0 / 255.0), (nfloat)(248.0 / 255.0));
        public static UIColor NaturalWhite = UIColor.White;
        public static UIColor NaturalBlack = UIColor.Black;


        public static UIColor ChangeAlpha(this UIColor color, float alpha)
        {
            nfloat r, g, b, a;
            color.GetRGBA(out r, out g, out b, out a);
            return UIColor.FromRGBA(r, g, b, a * alpha);
        }
    }
}
