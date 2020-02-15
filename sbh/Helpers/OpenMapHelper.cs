using Foundation;
using UIKit;

namespace sbh.Helpers
{
    public class OpenMapHelper
    {
        public static void OpenMap(string mapAddress)
        {
            var encoded = new NSString("https://www.google.com/maps/?daddr=" + mapAddress).CreateStringByAddingPercentEscapes(NSStringEncoding.UTF8);

            var googleMapUrl = NSUrl.FromString(encoded);

            if (UIApplication.SharedApplication.CanOpenUrl(googleMapUrl))
                UIApplication.SharedApplication.OpenUrl(googleMapUrl);
        }
    }
}
